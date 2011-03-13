braceExpression
	" { elements } => BraceNode."

	| elements locations loc more |
	elements _ OrderedCollection new.
	locations _ OrderedCollection new.
	self advance.
	more _ hereType ~~ #rightBrace.
	[more]
		whileTrue: 
			[loc _ hereMark + requestorOffset.
			self expression
				ifTrue: 
					[elements addLast: parseNode.
					locations addLast: loc]
				ifFalse:
					[^self expected: 'Variable or expression'].
			more _ self match: #period].
	parseNode _ BraceNode new elements: elements sourceLocations: locations.
	(self match: #rightBrace)
		ifFalse: [^self expected: 'Period or right brace'].
	^true