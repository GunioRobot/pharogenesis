transferTo: newProc
	"Record a process to be awoken on the next interpreter cycle."

	| sched oldProc |
	sched _ self schedulerPointer.
	oldProc _ self fetchPointer: ActiveProcessIndex ofObject: sched.
	self storePointer: SuspendedContextIndex ofObject: oldProc withValue: activeContext.
	self storePointer: ActiveProcessIndex      ofObject:   sched withValue: newProc.
	self newActiveContext:
		(self fetchPointer: SuspendedContextIndex ofObject: newProc).
	reclaimableContextCount _ 0.