selectAll
	| sel |
	sel _ self selectedSuite.
	selectedSuites _ selectedSuites collect: [ :ea | true ].
	selectedSuites size isZero ifFalse: [
		sel isZero ifTrue: [ self selectedSuite: 1 ]
			ifFalse: [ self changed: #allSelections ]].
