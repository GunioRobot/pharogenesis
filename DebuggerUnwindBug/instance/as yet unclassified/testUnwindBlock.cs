testUnwindBlock
	"test if unwind blocks work properly"
	| sema process |
	sema := Semaphore forMutualExclusion.
	self assert: sema isSignaled.
	"deadlock on the semaphore"
	process := [sema critical:[sema wait]] forkAt: Processor userInterruptPriority.
	self deny: sema isSignaled.
	"terminate process"
	process terminate.
	self assert: sema isSignaled.
