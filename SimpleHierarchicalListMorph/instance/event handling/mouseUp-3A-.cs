mouseUp: event 
	| aMorph |
	aMorph := self itemFromPoint: event position.
	aMorph ifNil: [^self].
	aMorph highlightedForMouseDown ifFalse: [^self].
	aMorph highlightForMouseDown: false.
	model okToChange ifFalse: [^self].
	"No change if model is locked"
	((autoDeselect isNil or: [autoDeselect]) and: [aMorph == selectedMorph]) 
		ifTrue: [self setSelectedMorph: nil]
		ifFalse: [self setSelectedMorph: aMorph].
	Cursor normal show