addWeakDependent: anObject
	| finished index weakDependent |
	self isFinalizationSupported ifFalse:[^self].
	FinalizationLock critical:[
		finished := false.
		index := 0.
		[index := index + 1.
		finished not and:[index <= FinalizationDependents size]] whileTrue:[
			weakDependent := FinalizationDependents at: index.
			weakDependent isNil ifTrue:[
				FinalizationDependents at: index put: anObject.
				finished := true.
			].
		].
		finished ifFalse:[
			"Grow linearly"
			FinalizationDependents := FinalizationDependents, (WeakArray new: 10).
			FinalizationDependents at: index put: anObject.
		].
	] ifError:[:msg :rcvr| rcvr error: msg].