transformCase: encoder

	| caseNode |
	caseNode _ arguments first.
	(caseNode isKindOf: BraceNode)
		ifTrue:
			[^(caseNode blockAssociationCheck: encoder) and:
			 	[arguments size = 1 or:
					[self checkBlock: arguments last as: 'otherwise arg' from: encoder]]].
	(caseNode canBeSpecialArgument and: [(caseNode isMemberOf: BlockNode) not])
		ifTrue:
			[^false]. "caseOf: variable"
	^encoder notify: 'caseOf: argument must be a brace construct or a variable'