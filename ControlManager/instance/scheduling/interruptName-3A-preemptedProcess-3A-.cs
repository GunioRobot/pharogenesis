interruptName: labelString preemptedProcess: theInterruptedProcess
	"Create a Notifier on the active scheduling process with the given label. Make the Notifier the active controller."
	| suspendingList newActiveController preemptedProcess |

	preemptedProcess := theInterruptedProcess ifNil: [Processor preemptedProcess].
	preemptedProcess == activeControllerProcess
		ifFalse: [(suspendingList := preemptedProcess suspendingList) == nil
				ifTrue: [preemptedProcess suspend]
				ifFalse: [suspendingList remove: preemptedProcess.
						preemptedProcess offList]].

	(suspendingList := activeControllerProcess suspendingList) == nil
		ifTrue: [activeControllerProcess == Processor activeProcess
					ifTrue: [activeControllerProcess suspend]]
		ifFalse: [suspendingList remove: activeControllerProcess ifAbsent:[].
				activeControllerProcess offList].

	activeController ~~ nil ifTrue: [
		"Carefully de-emphasis the current window."
		activeController view topView deEmphasizeForDebugger].

	newActiveController :=
		(Debugger
			openInterrupt: labelString
			onProcess: preemptedProcess) controller.
	newActiveController centerCursorInView.
	self activeController: newActiveController.
