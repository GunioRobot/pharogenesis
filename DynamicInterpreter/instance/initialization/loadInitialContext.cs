loadInitialContext

	| sched proc |
	self inline: false.
	self preTranslateContextMethods.
	sched _ self fetchPointer: ValueIndex ofObject: (self splObj: SchedulerAssociation).
	proc _ self fetchPointer: ActiveProcessIndex ofObject: sched.
	self copyContextToCache: (self fetchPointer: SuspendedContextIndex ofObject: proc).
	self fetchContextRegisters: activeCachedContext.
	self assertStackPointerIsExternal.