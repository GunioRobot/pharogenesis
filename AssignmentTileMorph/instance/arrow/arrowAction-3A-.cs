arrowAction: delta
	| index aList |
	owner ifNil: [^ self].
	operatorOrExpression ifNotNil:
		[aList _ #(: Incr: Decr: Mult:).
		index _ aList indexOf: assignmentSuffix asSymbol.
		index  > 0 ifTrue:
			[self setAssignmentSuffix: (aList atWrap: index + delta).
			self acceptNewLiteral]]