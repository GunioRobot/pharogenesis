drawSubdivisionEdgesOn: cc
	subdivision ifNil:[^self].
	subdivision edgesDo:[:e|
		cc line: e origin to: e destination width: 1 color: e classificationColor].