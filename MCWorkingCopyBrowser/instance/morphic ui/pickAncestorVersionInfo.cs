pickAncestorVersionInfo
	| ancestors index |
	ancestors _ workingCopy ancestry allAncestors.
	index _ (PopUpMenu labelArray: (ancestors collect: [:ea | ea name]))
				startUpWithCaption: 'Ancestor:'.
	^ index = 0 ifFalse: [ ancestors at: index]