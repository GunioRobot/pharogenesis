environmentRemoveKey: key ifAbsent: errorBlock
	env ifNil: [^ errorBlock value].
	^ env removeKey: key ifAbsent: errorBlock