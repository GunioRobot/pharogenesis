doubleClick: event onItem: aMorph
	doubleClickSelector isNil ifTrue: [^ self].
	selectedMorph ifNil: [self setSelectedMorph: aMorph].
	^ self model perform: doubleClickSelector