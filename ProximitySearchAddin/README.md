# Proximity Search Add-in

## תיאור

Add-in פשוט עבור Microsoft Word שמאפשר חיפוש Proximity מתקדם - מצא שתי מילים שנמצאות בקרבה מסוימת זו לזו במסמך.

זה גרסה פשוטה ונקייה שמכילה **רק** את פונקציונליות ה-Proximity Search מה-add-in המלא Wordiscover.

---

## תכונות

✨ **חיפוש קרבה פשוט**:
- חפש שתי מילים/ביטויים שנמצאים בקרבה מסוימת
- הגדר מספר מילים מקסימלי ביניהן
- תמיכה בחיפוש בין פסקאות (Paragraph Proximity)

✨ **אופציות מתקדמות**:
- **Case Sensitive** - תלוי/בלתי תלוי רישיות
- **Logical NOT** - מצא את המילה הראשונה שהשנייה *לא* בקרבתה
- **Word Proximity** - כמה מילים מקסימום בין שני הביטויים
- **Paragraph Proximity** - חפש גם בין פסקאות (2-10 פסקאות)

✨ **ממשק ידידותי**:
- חלון קופץ פשוט וברור
- תוצאות עם הדגשה צהובה במסמך
- ניווט מהיר לתוצאות
- ניקוי הדגשות בלחיצת כפתור

---

## דרישות מערכת

- ✅ Windows 10/11
- ✅ Microsoft Word 2013 ואילך
- ✅ .NET Framework 4.8
- ✅ Visual Studio Tools for Office Runtime

---

## התקנה

### שיטה 1: בנייה מ-Source Code

1. **פתח את הפרויקט** ב-Visual Studio (2019+)
   ```
   ProximitySearchAddin/ProximitySearchAddin.csproj
   ```

2. **Restore NuGet Packages** (אם נדרש)

3. **Build הפרויקט**:
   - `Build > Build Solution` (Ctrl+Shift+B)
   - או: `Build > Configuration Manager` → בחר `Release` → Build

4. **Publish** (ליצירת installer):
   - לחיצה ימנית על הפרויקט → `Publish`
   - בחר תיקיית יעד
   - הרץ את `setup.exe` שנוצר

### שיטה 2: התקנה מ-VSTO

אם קיבלת קובץ `.vsto`:
1. וודא ש-VSTO Runtime מותקן
2. לחץ לחיצה כפולה על הקובץ `.vsto`
3. עקוב אחר ההוראות

---

## שימוש

### פתיחת החיפוש

1. פתח מסמך Word
2. לך ל-Ribbon → **Add-ins** (או **תוספים**)
3. לחץ על **Proximity Search**
4. חלון החיפוש ייפתח

### ביצוע חיפוש

1. **Search Term 1**: הזן את המילה/ביטוי הראשון
2. **Search Term 2**: הזן את המילה/ביטוי השני
3. **הגדר אופציות** (לפי צורך):
   - ☐ Case Sensitive
   - ☐ Logical NOT
   - **Word Proximity**: מספר מילים מקסימלי (1-99)
   - ☐ Paragraph Proximity: חיפוש בין פסקאות (2-10)
4. לחץ **Search**
5. התוצאות יופיעו ברשימה מימין
6. לחץ על תוצאה כדי לנווט אליה במסמך

### דוגמאות

#### דוגמה 1: חיפוש קרבה בסיסי
```
Search Term 1: computer
Search Term 2: science
Word Proximity: 5
```
**תוצאה**: ימצא "computer science", "computer and science", "computer programming in science", וכו'

#### דוגמה 2: Logical NOT
```
Search Term 1: apple
Search Term 2: computer
☑ Logical NOT
Word Proximity: 3
```
**תוצאה**: ימצא "apple" רק כש-"computer" *לא* נמצא בקרבת 3 מילים

#### דוגמה 3: Paragraph Proximity
```
Search Term 1: introduction
Search Term 2: conclusion
☑ Paragraph Proximity: 3
```
**תוצאה**: ימצא "introduction" ו-"conclusion" שנמצאים בטווח של 3 פסקאות

---

## ארכיטקטורה

המבנה פשוט וקל להבנה:

```
ProximitySearchAddin/
├── ProximitySearchForm.cs         ← UI Form
├── ProximitySearchForm.Designer.cs
├── ProximityFinder.cs             ← מנוע החיפוש
├── FinderHelpers.cs               ← לוגיקת proximity
├── ProxSearchSettings.cs          ← הגדרות החיפוש
├── DocumentHelpers.cs             ← עזרים ל-Word API
├── ThisAddIn.cs                   ← נקודת כניסה
├── Ribbon.cs                      ← כפתור ב-Ribbon
└── ProximitySearchAddin.csproj    ← קובץ פרויקט
```

### רכיבים עיקריים

1. **ProximitySearchForm**: ממשק המשתמש
2. **ProximityFinder**: המנוע שמבצע את החיפוש (multi-threaded)
3. **FinderHelpers**: הלוגיקה של proximity matching
4. **ProxSearchSettings**: אובייקט הגדרות
5. **DocumentHelpers**: גישה ל-Word Document

---

## פיתוח

### הוספת תכונות

הקוד מודולרי וקל להרחבה:

- **שינוי UI**: ערוך את `ProximitySearchForm.Designer.cs`
- **שינוי לוגיקה**: ערוך את `FinderHelpers.cs` או `ProximityFinder.cs`
- **הוספת אופציות**: הוסף ל-`ProxSearchSettings.cs`

### Build Instructions

```powershell
# מ-Visual Studio Command Prompt
cd ProximitySearchAddin
msbuild ProximitySearchAddin.csproj /p:Configuration=Release
```

---

## ביצועים

- **Multi-threaded**: החיפוש מקבילי (Parallel.ForEach)
- **Progress reporting**: עדכון התקדמות בזמן אמת
- **Cancellable**: אפשר לבטל חיפוש ארוך

### טיפים לביצועים טובים יותר

- מסמכים קטנים (< 1000 פסקאות): מהיר מאוד
- מסמכים בינוניים (1000-5000): כמה שניות
- מסמכים גדולים (> 5000): עשוי לקחת יותר זמן

---

## פתרון בעיות

### "No active document found"
- וודא שיש מסמך פתוח ב-Word

### החיפוש איטי
- נסה לצמצם את טווח הפסקאות ב-Paragraph Proximity
- וודא שה-document לא גדול מדי

### התוצאות לא נכונות
- בדוק את ההגדרות (Case Sensitive, Word Proximity)
- נסה ערכים שונים של Word Proximity

---

## השוואה ל-Wordiscover המלא

| תכונה | Proximity Search Add-in | Wordiscover מלא |
|-------|------------------------|------------------|
| חיפוש רגיל | ❌ | ✅ |
| Proximity Search | ✅ | ✅ |
| Replace | ❌ | ✅ |
| ממשק | חלון קופץ | Panel בצד |
| גמישות UI | - | ✅ Resizable |
| מורכבות | פשוט | מתקדם |

**מתי להשתמש ב-Add-in הזה?**
- אתה צריך רק Proximity Search
- אתה מעדיף ממשק פשוט
- אתה רוצה משהו קל ומהיר

**מתי להשתמש ב-Wordiscover המלא?**
- צריך גם חיפוש רגיל ו-Replace
- רוצה UI גמיש וניתן להתאמה
- צריך תכונות מתקדמות נוספות

---

## רישיון

ראה את LICENSE.md בשורש הפרויקט.

---

## תמיכה

לשאלות, בעיות או הצעות:
- פתח issue ב-GitHub
- צור pull request עם שיפורים

---

**נבנה מתוך Wordiscover** - גרסה פשוטה ונקייה עם רק הקוד הדרוש ל-Proximity Search!
