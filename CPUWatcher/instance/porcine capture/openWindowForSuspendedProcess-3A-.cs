openWindowForSuspendedProcess: aProcess

	Smalltalk isMorphic
		ifTrue: [ WorldState addDeferredUIMessage: [ self openMorphicWindowForSuspendedProcess: aProcess ] ]
		ifFalse: [ [ self openMVCWindowForSuspendedProcess: aProcess ] forkAt: Processor userSchedulingPriority ]
