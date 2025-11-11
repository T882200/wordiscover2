# הוראות בנייה של Wordiscover VSTO Add-in

## דרישות מקדימות

1. **Windows OS** (Windows 10/11)
2. **Visual Studio 2019 או חדש יותר** עם:
   - Office/SharePoint Development workload
   - .NET Framework 4.8 SDK
3. **Microsoft Office Word** (2013 ואילך)
4. **התלות**: PanelScrollControl.dll (מצוין בפרויקט)

---

## שיטה 1: בנייה עם Visual Studio (מומלץ)

### צעדים:

1. **שכפל או הורד את הקוד מ-GitHub**:
   ```bash
   git clone [repository-url]
   cd wordiscover2
   git checkout claude/wordiscover-ui-responsive-011CV2WmMiy3RKBaw1QpY4fE
   ```

2. **פתח את הפרויקט**:
   - פתח את הקובץ `Wordiscover.sln` ב-Visual Studio

3. **בדוק תלויות**:
   - וודא ש-PanelScrollControl.dll קיים בנתיב: `..\..\PanelScrollControl-master\PanelScrollControl-master\PanelScrollControl\bin\Release\PanelScrollControl.dll`
   - אם הקובץ חסר, תצטרך להוריד אותו מ-[PanelScrollControl GitHub](https://github.com/Cintio/PanelScrollControl)

4. **שנה ל-Release Configuration**:
   - בתפריט העליון: `Build > Configuration Manager`
   - שנה `Active solution configuration` ל-`Release`

5. **בנה את הפרויקט**:
   - `Build > Build Solution` (או Ctrl+Shift+B)

6. **פרסם את ה-Add-in** (ליצירת installer):
   - לחץ לחיצה ימנית על הפרויקט `Wordiscover`
   - בחר `Publish`
   - בחר תיקיית יעד (למשל: `C:\Wordiscover-Release`)
   - לחץ `Finish` כדי ליצור את קבצי ההתקנה

7. **מצא את קבצי ההפצה**:
   - התיקייה: `Wordiscover\bin\Release\` - מכילה את ה-DLL files
   - תיקיית Publish - מכילה את setup.exe והקבצים להתקנה

---

## שיטה 2: בנייה עם MSBuild (שורת פקודה)

### צעדים:

1. **פתח Developer Command Prompt for Visual Studio**:
   - חפש בתפריט Start: "Developer Command Prompt for VS 2019" (או הגרסה שלך)

2. **נווט לתיקיית הפרויקט**:
   ```cmd
   cd C:\path\to\wordiscover2
   ```

3. **שחזר חבילות NuGet** (אם נדרש):
   ```cmd
   nuget restore Wordiscover.sln
   ```

4. **בנה את הפרויקט**:
   ```cmd
   msbuild Wordiscover.sln /p:Configuration=Release /p:Platform="Any CPU" /v:minimal
   ```

5. **פרסם** (אופציונלי):
   ```cmd
   msbuild Wordiscover\Wordiscover.csproj /t:Publish /p:Configuration=Release /p:PublishUrl="C:\Wordiscover-Release\"
   ```

---

## קבצי פלט

לאחר בנייה מוצלחת:

### ✅ קבצי Build רגילים (תיקיית bin\Release):
- `Wordiscover.dll` - ה-Add-in עצמו
- `Wordiscover.dll.manifest` - manifest file
- `Wordiscover.vsto` - הקובץ להתקנה
- קבצי תלות נוספים

### ✅ קבצי Publish (תיקיית publish):
- `setup.exe` - תוכנית ההתקנה
- `Wordiscover.vsto` - קובץ ה-deployment
- תיקייה עם כל הקבצים הנדרשים

---

## התקנה

### מהמשתמש הקצה:

1. העתק את תיקיית ה-publish למחשב היעד
2. הרץ את `setup.exe`
3. עקוב אחר ההוראות על המסך
4. פתח את Word - ה-Add-in אמור להופיע אוטומטית

### התקנה ידנית (למפתחים):

1. העתק את הקבצים מ-`bin\Release` למיקום מתאים
2. רשום את ה-Add-in ב-Registry:
   - HKEY_CURRENT_USER\Software\Microsoft\Office\Word\Addins\Wordiscover
   - הוסף keys מתאימים (Manifest, LoadBehavior, etc.)

---

## פתרון בעיות

### בעיה: "Cannot find PanelScrollControl.dll"
**פתרון**: הורד את [PanelScrollControl](https://github.com/Cintio/PanelScrollControl), בנה אותו, ושים את הDLL בנתיב הנכון.

### בעיה: "Office Tools not installed"
**פתרון**: התקן את Visual Studio עם Office Development workload.

### בעיה: Build נכשל עם שגיאות
**פתרון**: וודא שיש לך .NET Framework 4.8 SDK מותקן.

---

## שינויים בגרסה האחרונה

✨ **גרסה עם UI משופר** - Branch: `claude/wordiscover-ui-responsive-011CV2WmMiy3RKBaw1QpY4fE`

- הוספו splitters בין כל חלקי הUI
- ניתן להתאים גודל כל סעיף (Find, Replace, Proximity, Results)
- שיפור תצוגת Proximity Search עם יכולת הגדלה
- גמישות מקסימלית בניהול שטח העבודה

---

## תמיכה

לבעיות או שאלות, פתח issue ב-GitHub repository.
