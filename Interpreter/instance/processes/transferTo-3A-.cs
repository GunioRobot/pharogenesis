transferTo: aProc
	"Record a process to be awoken on the next interpreter cycle.
	ikp 11/24/1999 06:07 -- added hook for external runtime compiler"

	| sched oldProc newProc |
	newProc _ aProc.
	sched _ self schedulerPointer.
	oldProc _ self fetchPointer: ActiveProcessIndex ofObject: sched.
	self storePointer: ActiveProcessIndex ofObject: sched withValue: newProc.
	compilerInitialized ifTrue: [
		self compilerProcessChange: oldProc to: newProc.
	] ifFalse: [
		self storePointer: SuspendedContextIndex ofObject: oldProc withValue: activeContext.
		self newActiveContext: (self fetchPointer: SuspendedContextIndex ofObject: newProc)
	].
	reclaimableContextCount _ 0.