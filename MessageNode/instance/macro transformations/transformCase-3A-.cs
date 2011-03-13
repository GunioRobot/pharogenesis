transformCase: encoder

	| caseNode |
	caseNode := arguments first.
	(caseNode isMemberOf: BraceNode) ifTrue:
		[((caseNode blockAssociationCheck: encoder)
		  and: [arguments size = 1
			    or: [self checkBlock: arguments last as: 'otherwise arg' from: encoder]]) ifFalse:
			[^false].
		 caseNode elements do:
			[:messageNode|
			messageNode receiver noteOptimized.
			messageNode arguments first noteOptimized].
		 arguments size = 2 ifTrue:
			[arguments last noteOptimized].
		 ^true].
	(caseNode canBeSpecialArgument and: [(caseNode isMemberOf: BlockNode) not]) ifTrue:
		[^false]. "caseOf: variable"
	^encoder notify: 'caseOf: argument must be a brace construct or a variable'