# 🔨 בנייה והתקנה של Wordiscover

## 📋 תקציר

הפרויקט עודכן עם UI משופר וגמיש. כדי לבנות את ה-Add-in, תצטרך **מחשב Windows** עם Visual Studio.

---

## 🚀 בנייה מהירה (Windows)

### אופציה 1: שימוש בסקריפט PowerShell (הכי פשוט!)

1. פתח **PowerShell** בתיקיית הפרויקט
2. הרץ:
   ```powershell
   .\Build-Wordiscover.ps1 -Publish
   ```
3. הקבצים להתקנה יהיו בתיקייה `Build-Output`

### אופציה 2: Visual Studio

1. פתח את `Wordiscover.sln` ב-Visual Studio
2. שנה ל-**Release** configuration
3. **Build → Build Solution** (Ctrl+Shift+B)
4. לחיצה ימנית על הפרויקט → **Publish**
5. בחר תיקיית יעד ולחץ **Finish**

---

## 📦 מה נדרש?

- ✅ Windows 10/11
- ✅ Visual Studio 2019+ עם Office Development
- ✅ .NET Framework 4.8
- ✅ Microsoft Word 2013+

---

## 📖 הוראות מפורטות

ראה את הקובץ **BUILD_INSTRUCTIONS.md** להוראות מלאות בעברית.

---

## ✨ מה השתנה בגרסה החדשה?

### שיפורי UI:

- ✅ **Splitters גמישים** - גרור ושנה גודל של כל חלק
- ✅ **Proximity Search משופר** - יותר מקום לראות פרטים
- ✅ **גמישות מקסימלית** - התאם את ה-workspace לצרכים שלך

### איך זה עובד:

1. פתח את Wordiscover ב-Word
2. תראה **קווים מפרידים** (splitters) בין החלקים
3. **גרור** את הקווים כדי לשנות גודל
4. כל חלק (Find, Replace, Proximity, Results) ניתן להתאמה!

---

## 🆘 עזרה

### בעיות נפוצות:

**שגיאה: "Cannot find PanelScrollControl.dll"**
- הורד מ-[GitHub](https://github.com/Cintio/PanelScrollControl)
- בנה אותו ושים ב-`..\..\PanelScrollControl-master\...`

**שגיאה: "Office Tools not installed"**
- התקן Visual Studio עם Office Development workload

---

## 📝 קבצים חשובים

| קובץ | תיאור |
|------|--------|
| `Build-Wordiscover.ps1` | סקריפט בנייה אוטומטי |
| `BUILD_INSTRUCTIONS.md` | הוראות מפורטות |
| `Wordiscover.sln` | קובץ פתרון Visual Studio |

---

## 💡 טיפ

אם אתה רוצה רק לבנות בלי installer:
```powershell
.\Build-Wordiscover.ps1
```

הקבצים יהיו ב: `Wordiscover\bin\Release\`

---

**Branch:** `claude/wordiscover-ui-responsive-011CV2WmMiy3RKBaw1QpY4fE`

בהצלחה! 🎉
