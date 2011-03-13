pickAncestorVersionInfo
	| ancestors index |
	ancestors := workingCopy ancestry breadthFirstAncestors.
	index := (PopUpMenu labelArray: (ancestors collect: [:ea | ea name]))
				startUpWithCaption: 'Ancestor:'.
	^ index = 0 ifFalse: [ ancestors at: index]