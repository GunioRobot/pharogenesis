mouseUp: event onItem: aMorph 
	aMorph ifNotNil: [aMorph highlightForMouseDown: false].
	model okToChange ifFalse: [
		^ self].
	"No change if model is locked"
	((autoDeselect == nil or: [autoDeselect]) and: [aMorph == selectedMorph])
		ifTrue: [self setSelectedMorph: nil]
		ifFalse: [self setSelectedMorph: aMorph].
	Cursor normal show.
