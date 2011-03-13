scrollbarThickness
	"Answer the width or height of a scrollbar as appropriate to
	its orientation."
	
	^Preferences scrollBarsNarrow
		ifTrue: [10]
		ifFalse: [14]