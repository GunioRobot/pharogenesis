loadInitialContext

	| sched proc |
	sched _ self fetchPointer: ValueIndex ofObject: (self splObj: SchedulerAssociation).
	proc _ self fetchPointer: ActiveProcessIndex ofObject: sched.
	activeContext _ self fetchPointer: SuspendedContextIndex ofObject: proc.
	(activeContext < youngStart) ifTrue: [ self beRootIfOld: activeContext ].
	self fetchContextRegisters: activeContext.
	reclaimableContextCount _ 0.