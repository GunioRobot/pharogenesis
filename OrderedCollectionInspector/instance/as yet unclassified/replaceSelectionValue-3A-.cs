replaceSelectionValue: anObject 
	"The receiver has a list of variables of its inspected object. One of these 
	is selected. The value of the selected variable is set to the value, 
	anObject."
	| basicIndex |
	(selectionIndex - 2) <= object class instSize
		ifTrue: [^ super replaceSelectionValue: anObject].
	basicIndex _ selectionIndex - 2 - object class instSize.
	(object size <= (self i1 + self i2)  or: [basicIndex <= self i1])
		ifTrue: [^object at: basicIndex put: anObject]
		ifFalse: [^object at: object size - (self i1 + self i2) + basicIndex
					put: anObject]