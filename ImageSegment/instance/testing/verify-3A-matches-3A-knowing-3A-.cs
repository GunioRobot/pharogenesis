verify: ob1 matches: ob2 knowing: matchDict

	| priorMatch first |
	ob1 == ob2 ifTrue:
		["If two pointers are same, they must be ints or in outPointers"
		((ob1 isMemberOf: SmallInteger) and: [ob1 = ob2]) ifTrue: [^ self].
		((ob1 isKindOf: Behavior) and: [ob1 indexIfCompact = ob2 indexIfCompact]) ifTrue: [^ self].
		(outPointers includes: ob1) ifTrue: [^ self].
		self halt].
	priorMatch _ matchDict at: ob1 ifAbsent: [nil].
	priorMatch == nil
		ifTrue: [matchDict at: ob1 put: ob2]
		ifFalse: [priorMatch == ob2
					ifTrue: [^ self]
					ifFalse: [self halt]].
	self verify: ob1 class matches: ob2 class knowing: matchDict.
	ob1 class isVariable ifTrue: 
		[ob1 basicSize = ob2 basicSize ifFalse: [self halt].
		first _ 1.
		(ob1 isMemberOf: CompiledMethod) ifTrue: [first _ ob1 initialPC].
		first to: ob1 basicSize do:
			[:i | self verify: (ob1 basicAt: i) matches: (ob2 basicAt: i) knowing: matchDict]].
	ob1 class instSize = ob2 class instSize ifFalse: [self halt].
	1 to: ob1 class instSize do:
		[:i | self verify: (ob1 instVarAt: i) matches: (ob2 instVarAt: i) knowing: matchDict].
	(ob1 isMemberOf: CompiledMethod) ifTrue:
		[ob1 header = ob2 header ifFalse: [self halt].
		ob1 numLiterals = ob2 numLiterals ifFalse: [self halt].
		1 to: ob1 numLiterals do:
			[:i | self verify: (ob1 literalAt: i) matches: (ob2 literalAt: i) knowing: matchDict]]