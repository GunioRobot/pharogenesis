initialize
	super initialize.
	self color: Color black.
	font := Preferences standardListFont.
	listItems := #().
	selectedRow := nil.
	selectedRows := PluggableSet integerSet.
	self adjustHeight.