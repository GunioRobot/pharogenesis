selection
	"The receiver has a list of variables of its inspected object.
	One of these is selected. Answer the value of the selected variable."
	| basicIndex |
	(selectionIndex - 2) <= object class instSize
		ifTrue: [^ super selection].
	basicIndex _ selectionIndex - 2 - object class instSize.
	(object size <= (self i1 + self i2)  or: [basicIndex <= self i1])
		ifTrue: [^ object at: basicIndex]
		ifFalse: [^ object at: object size - (self i1 + self i2) + basicIndex]