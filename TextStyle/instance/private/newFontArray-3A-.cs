newFontArray: anArray
	"Currently there is no supporting protocol for changing these arrays. If an editor wishes to implement margin setting, then a copy of the default should be stored with these instance variables.  
	, Make size depend on first font."

	fontArray _ anArray.
	lineGrid _ (fontArray at: 1) height + leading.	"For whole family"
	baseline _ (fontArray at: 1) ascent + leading.
	alignment _ 0.
	firstIndent _ 0.
	restIndent _ 0.
	rightIndent _ 0.
	tabsArray _ DefaultTabsArray.
	marginTabsArray _ DefaultMarginTabsArray
"
TextStyle allInstancesDo: [:ts | ts newFontArray: TextStyle default fontArray].
"