initializePreferences
	"initialize the receiver's Preferences"
	retractableScrollBar _ (Preferences valueOfFlag: #inboardScrollbars) not.
	scrollBarOnLeft _ (Preferences valueOfFlag: #scrollBarsOnRight) not.
	

