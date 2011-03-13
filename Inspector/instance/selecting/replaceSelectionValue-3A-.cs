replaceSelectionValue: anObject 
	"The receiver has a list of variables of its inspected object. One of these 
	is selected. The value of the selected variable is set to the value, 
	anObject."
	| basicIndex |
	selectionIndex = 1 ifTrue: [^ object].
	object class isVariable
		ifFalse: [^ object instVarAt: selectionIndex - 2 put: anObject].
	basicIndex _ selectionIndex - 2 - object class instSize.
	(object basicSize <= (self i1 + self i2)  or: [basicIndex <= self i1])
		ifTrue: [^object basicAt: basicIndex put: anObject]
		ifFalse: [^object basicAt: object basicSize - (self i1 + self i2) + basicIndex
					put: anObject]