selectorsWithArgs: numberOfArgs
	"Return all selectors defined in this class that take this number of arguments.  Could use String.keywords.  Could see how compiler does this."

	| list num |
	list _ OrderedCollection new.
	self selectorsDo: [:aSel | 
		num _ aSel count: [:char | char == $:].
		num = 0 ifTrue: [aSel last isLetter ifFalse: [num _ 1]].
		num = numberOfArgs ifTrue: [list add: aSel]].
	^ list