transferTo: newProcArg
	"Record a process to be awoken on the next interpreter cycle.
	Assumes: IP and SP are external."

	| sched oldProc suspendedContext newProc |
	self pushRemappableOop: newProcArg.
	suspendedContext _ self flushCacheFrom: activeCachedContext.		"GC!"
	newProc _ self popRemappableOop.
	self assertIsStableContext: suspendedContext.
	self assertIsProcess: newProc.
	sched _ self schedulerPointer.
	oldProc _ self fetchPointer: ActiveProcessIndex ofObject: sched.
	self storePointer: SuspendedContextIndex ofObject: oldProc withValue: suspendedContext.
	self storePointer: ActiveProcessIndex      ofObject:   sched withValue: newProc.
	suspendedContext _ self fetchPointer: SuspendedContextIndex ofObject: newProc.
	self assertIsStableContext: suspendedContext.
	self copyContextToCache: suspendedContext.
	self fetchContextRegisters: activeCachedContext.