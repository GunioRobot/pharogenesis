interruptName: labelString
	"Create a Notifier on the active scheduling process with the given label. Make the Notifier the active controller."

	| suspendingList newActiveController |
	suspendingList _ activeControllerProcess suspendingList.
	suspendingList isNil ifTrue: [
		activeControllerProcess == Processor activeProcess
			ifTrue: [activeControllerProcess suspend].
	] ifFalse: [
		suspendingList remove: activeControllerProcess.
		activeControllerProcess offList].

	activeController ~~ nil ifTrue: [
		"Carefully de-emphasis the current window."
		activeController view topView deEmphasizeForDebugger].

	newActiveController _
		(Debugger
			openInterrupt: labelString
			onProcess: activeControllerProcess) controller.
	newActiveController centerCursorInView.
	self activeController: newActiveController.
