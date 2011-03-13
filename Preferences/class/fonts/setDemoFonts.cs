setDemoFonts
	"Preferences setDemoFonts"
	|size font codeFont titleFont|
	size := UIManager default request: 'Base font size?' initialAnswer: '14'.
	size isEmptyOrNil ifTrue: [^ self].
	size := size asInteger.
	(size isNil or: [size <= 0]) ifTrue: [^ self].
	font := LogicalFont familyName: 'DejaVu Sans' pointSize: size.
	codeFont := LogicalFont familyName: 'DejaVu Sans Mono' pointSize: size.
	titleFont := LogicalFont familyName: 'DejaVu Serif' pointSize: size.

Preferences
	setListFontTo: font;
	setMenuFontTo: font;
	setCodeFontTo: codeFont;
	setButtonFontTo: font;
	setSystemFontTo: font;
	setWindowTitleFontTo: titleFont.