buttonWidth
	"Answer based on scrollbar size."
	
	^(Preferences scrollBarsNarrow ifTrue: [12] ifFalse: [16])
		max: self theme expanderTitleControlButtonWidth