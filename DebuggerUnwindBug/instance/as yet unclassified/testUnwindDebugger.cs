testUnwindDebugger
	"test if unwind blocks work properly when a debugger is closed"
	| sema process debugger top |
	sema := Semaphore forMutualExclusion.
	self assert: sema isSignaled.
	process := [sema critical:[sema wait]] forkAt: Processor userInterruptPriority.
	self deny: sema isSignaled.

	"everything set up here - open a debug notifier"
	debugger := Debugger openInterrupt: 'test' onProcess: process.
	"get into the debugger"
	debugger debug.
	top := debugger topView.
	"set top context"
	debugger toggleContextStackIndex: 1.
	"close debugger"
	top delete.

	"and see if unwind protection worked"
	self assert: sema isSignaled.