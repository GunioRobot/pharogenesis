primitiveWait

	| sema excessSignals activeProc |
	sema _ self stackTop.  "rcvr"
	self assertClassOf: sema is: (self splObj: ClassSemaphore).
	successFlag ifTrue: [
		excessSignals _
			self fetchInteger: ExcessSignalsIndex ofObject: sema.
		excessSignals > 0 ifTrue: [
			self storeInteger: ExcessSignalsIndex
				ofObject: sema withValue: excessSignals - 1.
		] ifFalse: [
			activeProc _ self fetchPointer: ActiveProcessIndex
								 ofObject: self schedulerPointer.
			self addLastLink: activeProc toList: sema.
			self transferTo: self wakeHighestPriority.
		].
	].