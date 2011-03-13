generateIfQuick: methodBlock
	| v |
	(primitive = 0 and: [arguments size = 0 and: [block isQuick]])
		ifFalse: [^ self].
	v _ block code.
	v < 0
		ifTrue: [^ self].
	v = LdSelf
		ifTrue: [^ methodBlock value: CompiledMethod toReturnSelf].
	(v between: LdTrue and: LdMinus1 + 3)
		ifTrue: [^ methodBlock value: (CompiledMethod toReturnConstant: v - LdSelf)].
	v < ((CodeBases at: LdInstType) + (CodeLimits at: LdInstType))
		ifTrue: [^ methodBlock value: (CompiledMethod toReturnField: v)].
	v // 256 = 1
		ifTrue: [^ methodBlock value: (CompiledMethod toReturnField: v \\ 256)]