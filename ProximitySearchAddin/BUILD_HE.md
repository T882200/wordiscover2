# 🔨 הוראות בנייה - Proximity Search Add-in

## תקציר

זהו add-in פשוט ונקי שמכיל רק את פונקציונליות ה-Proximity Search.

---

## 📋 דרישות

- ✅ Windows 10/11
- ✅ Visual Studio 2019 ואילך עם Office Development
- ✅ .NET Framework 4.8
- ✅ Microsoft Word 2013+

---

## 🚀 בנייה מהירה

### אופציה 1: Visual Studio (הכי קל)

1. **פתח את הפרויקט**:
   ```
   ProximitySearchAddin\ProximitySearchAddin.csproj
   ```

2. **שנה ל-Release configuration**:
   - Build → Configuration Manager
   - בחר `Release`

3. **בנה את הפרויקט**:
   - Build → Build Solution (Ctrl+Shift+B)

4. **צור Installer** (אופציונלי):
   - לחיצה ימנית על הפרויקט → Publish
   - בחר תיקיית יעד (למשל: `C:\ProximitySearch-Release`)
   - לחץ Finish
   - הרץ את `setup.exe`

### אופציה 2: Command Line

```powershell
# פתח Developer Command Prompt for Visual Studio
cd ProximitySearchAddin

# בנייה
msbuild ProximitySearchAddin.csproj /p:Configuration=Release /v:minimal

# הקבצים יהיו ב:
# bin\Release\
```

---

## 📦 מה מתקבל?

לאחר בנייה:

### ✅ בתיקיית bin\Release:
```
ProximitySearchAddin.dll
ProximitySearchAddin.dll.manifest
ProximitySearchAddin.vsto
[קבצי תלות]
```

### ✅ לאחר Publish:
```
setup.exe           ← תוכנית התקנה
ProximitySearchAddin.vsto
[Application Files folder]
```

---

## 🎯 התקנה

### למשתמש קצה:

1. הרץ את `setup.exe`
2. עקוב אחר ההוראות
3. פתח Word
4. לך ל-Add-ins → Proximity Search

### למפתחים (F5 Debug):

1. פתח ב-Visual Studio
2. לחץ F5
3. Word ייפתח עם ה-Add-in

---

## 🔧 הבדלים מ-Wordiscover המלא

| תכונה | Proximity Search | Wordiscover |
|-------|------------------|-------------|
| גודל | ~50 KB | ~200 KB |
| קבצים | 9 קבצי .cs | 20+ קבצי .cs |
| תלויות | אין | PanelScrollControl.dll |
| ממשק | חלון קופץ | UI Panel |
| תכונות | רק Proximity | כל התכונות |

---

## 📝 מבנה הפרויקט

```
ProximitySearchAddin/
│
├── 📄 README.md                    ← תיעוד מלא
├── 📄 BUILD_HE.md                  ← המדריך הזה
├── 📄 ProximitySearchAddin.csproj  ← קובץ פרויקט
│
├── 🎨 UI Components
│   ├── ProximitySearchForm.cs
│   ├── ProximitySearchForm.Designer.cs
│   └── ProximitySearchForm.resx
│
├── 🔍 Search Logic
│   ├── ProximityFinder.cs          ← מנוע החיפוש
│   ├── FinderHelpers.cs            ← לוגיקת proximity
│   └── ProxSearchSettings.cs       ← הגדרות
│
├── 📚 Word Integration
│   ├── DocumentHelpers.cs          ← Word API helpers
│   ├── ThisAddIn.cs                ← נקודת כניסה
│   ├── Ribbon.cs                   ← כפתור ב-Ribbon
│   └── Ribbon.Designer.cs
│
└── 📦 Properties
    ├── AssemblyInfo.cs
    ├── Settings.settings
    └── Settings.Designer.cs
```

---

## ⚡ טיפים

### Build מהיר:
```powershell
# רק בנייה (ללא Publish)
msbuild /p:Configuration=Release /v:q
```

### ניקוי לפני בנייה:
```powershell
msbuild /t:Clean /p:Configuration=Release
msbuild /t:Build /p:Configuration=Release
```

### בדיקה אם הבנייה עבדה:
```powershell
dir bin\Release\*.dll
# אמור להראות: ProximitySearchAddin.dll
```

---

## 🐛 פתרון בעיות

### שגיאה: "Office Tools not installed"
**פתרון**: התקן Visual Studio עם Office Development workload

### שגיאה: "Framework 4.8 not found"
**פתרון**: הורד והתקן [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework/net48)

### Build הצליח אבל Word לא מזהה
**פתרון**:
1. וודא ש-VSTO Runtime מותקן
2. בדוק ב-Word: File → Options → Add-ins → Manage COM Add-ins

---

## 🎉 סיימת!

עכשיו יש לך add-in פשוט ועובד!

**לשימוש**:
1. פתח Word
2. לך ל-Add-ins
3. לחץ "Proximity Search"
4. תהנה! 🚀

---

**זכור**: זה גרסה פשוטה שמכילה רק Proximity Search.
אם אתה צריך גם Find רגיל ו-Replace, השתמש ב-Wordiscover המלא.
