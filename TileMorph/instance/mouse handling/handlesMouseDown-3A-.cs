handlesMouseDown: evt
	"Answer whether the receiver would handle the mouseDown represented by evt"

	| aPoint |
	aPoint _ evt cursorPoint.
	(operatorOrExpression notNil and: [upArrow notNil]) ifTrue: [^ true].
		"Click on the operator presents list of alternatives"

	upArrow ifNotNil: [((upArrow bounds containsPoint: aPoint) or: [downArrow bounds containsPoint: aPoint])
		ifTrue: [^ true]].
	suffixArrow ifNotNil: [(suffixArrow bounds containsPoint: aPoint)
		ifTrue: [^ true]].
	retractArrow ifNotNil: [(retractArrow bounds containsPoint: aPoint)
		ifTrue: [^ true]].
	^ super handlesMouseDown: evt