initialize
	"WeakArray initialize"
	"Do we need to initialize specialObjectsArray?"
	Smalltalk specialObjectsArray size < 42 
		ifTrue:[Smalltalk recreateSpecialObjectsArray].
	"Check if Finalization is supported by this VM"
	IsFinalizationSupported _ nil.
	self isFinalizationSupported ifFalse:[^self].

	FinalizationProcess notNil ifTrue:[FinalizationProcess terminate].
	FinalizationSemaphore := Smalltalk specialObjectsArray at: 42.
	FinalizationDependents isNil ifTrue:[
		FinalizationDependents := WeakArray new: 10.
	].
	FinalizationLock := Semaphore forMutualExclusion.
	FinalizationProcess := [self finalizationProcess] newProcess.
	FinalizationProcess priority: Processor userInterruptPriority.
	FinalizationProcess resume.