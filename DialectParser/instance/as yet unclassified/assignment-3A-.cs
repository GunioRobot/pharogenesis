assignment: varNode
	" 'set' (var) 'to' (expression) => AssignmentNode."
	| loc |
	(loc _ varNode assignmentCheck: encoder at: prevMark + requestorOffset) >= 0
		ifTrue: [^self notify: 'Cannot store into' at: loc].
	varNode nowHasDef.
	self advance.  " to "
	self expression ifFalse: [^self expected: 'Expression'].
	parseNode _ AssignmentNode new
				variable: varNode
				value: parseNode
				from: encoder.
	^ true