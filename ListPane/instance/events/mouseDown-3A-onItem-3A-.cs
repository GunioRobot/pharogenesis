mouseDown: event onItem: aMorph
	self setSelectedMorph: (aMorph == selectedMorph ifTrue: [nil] ifFalse: [aMorph])