assignment: varNode
	" var '_' expression => AssignmentNode."

	| loc |
	(loc _ varNode assignmentCheck: encoder at: prevMark + requestorOffset) >= 0
		ifTrue: [^self notify: 'Cannot store into' at: loc].
	self advance.
	self expression ifFalse: [^self expected: 'Expression'].
	parseNode _ AssignmentNode new
				variable: varNode
				value: parseNode
				from: encoder.
	^true