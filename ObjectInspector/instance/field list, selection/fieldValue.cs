fieldValue
	"Answer the value of the selected variable."
	| basicIndex |
	fieldIndex = 1 ifTrue: [^ object].
	(fieldIndex - 1) <= object class instSize
		ifTrue: [^ object instVarAt: fieldIndex - 1].
	basicIndex _ fieldIndex - 1 - object class instSize.
	((object basicSize <= (self nLow + self nHigh) or: [basicIndex <= self nLow]) or: [showAllIndices])
		ifTrue: [^ object basicAt: basicIndex].
	basicIndex < object basicSize - self nHigh + 1 ifTrue: [^ nil]. "..."
	^ object basicAt: object basicSize - (self nLow + self nHigh) + basicIndex