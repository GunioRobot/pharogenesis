newFontArray: anArray
	"Currently there is no supporting protocol for changing these arrays. If an editor wishes to implement margin setting, then a copy of the default should be stored with these instance variables.  
	8/20/96 tk, Make size depend on first font."

	fontArray _ anArray.
	lineGrid _ (anArray at: 1) lineGrid.	"For whole family"
	baseline _ (anArray at: 1) ascent + 1.
	alignment _ 0.
	firstIndent _ 0.
	restIndent _ 0.
	rightIndent _ 0.
	tabsArray _ DefaultTabsArray.
	marginTabsArray _ DefaultMarginTabsArray