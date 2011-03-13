setup
	
	"self setup"
	"setup the fonts/background color ala a real desktop.. this assumes these fonts exist on your system"
	
	| aStandardFont aBoldFont |	
		
	aStandardFont := LogicalFont familyName: 'Arial' pointSize: 9 stretchValue: 5 weightValue: 400 slantValue: 0.
	aBoldFont := LogicalFont familyName: 'Arial' pointSize: 9 stretchValue: 5 weightValue: 700 slantValue: 0.

	Preferences setWindowTitleFontTo: aBoldFont.
	Preferences setEToysTitleFontTo: aBoldFont.
	Preferences setFlapsFontTo: aBoldFont.
	
	Preferences setBalloonHelpFontTo: aStandardFont.
	Preferences setButtonFontTo: aStandardFont.
	Preferences setCodeFontTo: aStandardFont.
	Preferences setEToysFontTo: aStandardFont.
	Preferences setHaloLabelFontTo: aStandardFont.
	Preferences setListFontTo: aStandardFont.
	Preferences setMenuFontTo: aStandardFont.
	Preferences setPaintBoxButtonFontTo: aStandardFont.
	Preferences setSystemFontTo: aStandardFont.
	
	self world color: (Color r: 0.227 g: 0.431 b: 0.646).
	self beCurrent.