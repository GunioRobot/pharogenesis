initializePreferences
	"initialize the receiver's Preferences"
	retractableScrollBar _ false.
	scrollBarOnLeft _ (Preferences valueOfFlag: #scrollBarsOnRight) not.
	

