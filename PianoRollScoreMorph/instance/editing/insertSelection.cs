insertSelection

	self selection == nil ifTrue: [^ self].
	score insertEvents: NotePasteBuffer at: self selection.
	scorePlayer updateDuration.
	self rebuildFromScore 