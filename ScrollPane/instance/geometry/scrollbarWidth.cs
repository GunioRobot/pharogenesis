scrollbarWidth  "Includes border"
	(Preferences valueOfFlag: #scrollBarsNarrow)
		ifTrue: [^ 12]
		ifFalse: [^ 16]