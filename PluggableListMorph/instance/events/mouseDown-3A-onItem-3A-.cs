mouseDown: event onItem: aMorph
	model okToChange ifFalse: [^ self].  "No change if model is locked"
	((autoDeselect == nil or: [autoDeselect]) and: [aMorph == selectedMorph])
		ifTrue: [self setSelectedMorph: nil]
		ifFalse: [self setSelectedMorph: aMorph]