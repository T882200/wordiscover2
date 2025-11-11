using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace ProximitySearchAddin
{
    public partial class ProximitySearchForm : Form
    {
        private List<SearchResult> _results;
        private CancellationTokenSource _cts;
        private Stopwatch _stopwatch;
        private int _totalParagraphs;

        public ProximitySearchForm()
        {
            InitializeComponent();
            _results = new List<SearchResult>();
        }

        private void ProximitySearchForm_Load(object sender, EventArgs e)
        {
            // Initialize UI
            numericWordProximity.Value = 5;
            numericParaProximity.Value = 2;
            labelStatus.Text = "Ready";
            progressBar.Value = 0;

            // Setup list view
            listResults.View = View.Details;
            listResults.FullRowSelect = true;
            listResults.Columns.Add("#", 50);
            listResults.Columns.Add("Match", 400);
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtSearchTerm1.Text))
            {
                MessageBox.Show("Please enter the first search term.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSearchTerm2.Text))
            {
                MessageBox.Show("Please enter the second search term.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DocumentHelpers.ActiveDocument == null)
            {
                MessageBox.Show("No active document found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Clear previous results
                _results.Clear();
                listResults.Items.Clear();

                // Setup for search
                _totalParagraphs = DocumentHelpers.GetParagraphsCount();
                progressBar.Maximum = _totalParagraphs;
                progressBar.Value = 0;

                btnSearch.Enabled = false;
                btnCancel.Enabled = true;
                labelStatus.Text = "Searching...";

                _cts = new CancellationTokenSource();
                _stopwatch = Stopwatch.StartNew();

                var progress = new Progress<int>((count) =>
                {
                    progressBar.Value = count;
                    double percent = (count * 100.0 / _totalParagraphs);
                    labelStatus.Text = $"Searching... {percent:F0}% ({_results.Count} results)";
                });

                // Perform search
                await ProximityFinder.FindProximity(
                    txtSearchTerm1.Text,
                    txtSearchTerm2.Text,
                    chkCaseSensitive.Checked,
                    chkLogicalNot.Checked,
                    chkParaProximity.Checked,
                    (int)numericWordProximity.Value,
                    (int)numericParaProximity.Value,
                    _results,
                    progress,
                    _cts.Token);

                // Display results
                foreach (var result in _results)
                {
                    var item = new ListViewItem(result.Number.ToString());
                    item.SubItems.Add(result.Text?.Replace("\r", "").Replace("\n", " ").Trim());
                    item.Tag = result;
                    listResults.Items.Add(item);
                }

                _stopwatch.Stop();
                labelStatus.Text = $"Found {_results.Count} results in {_stopwatch.Elapsed.TotalSeconds:F2} seconds";
            }
            catch (OperationCanceledException)
            {
                labelStatus.Text = "Search cancelled";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during search: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                labelStatus.Text = "Error occurred";
            }
            finally
            {
                btnSearch.Enabled = true;
                btnCancel.Enabled = false;
                _stopwatch?.Stop();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _cts?.Cancel();
            btnCancel.Enabled = false;
            labelStatus.Text = "Cancelling...";
        }

        private void chkParaProximity_CheckedChanged(object sender, EventArgs e)
        {
            numericParaProximity.Enabled = chkParaProximity.Checked;
        }

        private void listResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listResults.SelectedItems.Count > 0)
            {
                var item = listResults.SelectedItems[0];
                var result = item.Tag as SearchResult;
                if (result?.Range != null)
                {
                    try
                    {
                        // Navigate to and highlight the result
                        result.Range.Select();
                        result.Range.HighlightColorIndex = Word.WdColorIndex.wdYellow;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error navigating to result: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnClearHighlights_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var result in _results)
                {
                    if (result.Range != null)
                    {
                        result.Range.HighlightColorIndex = Word.WdColorIndex.wdNoHighlight;
                    }
                }
                labelStatus.Text = "Highlights cleared";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error clearing highlights: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
