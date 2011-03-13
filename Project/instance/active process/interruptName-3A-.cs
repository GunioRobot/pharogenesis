interruptName: labelString
	"Create a Notifier on the active scheduling process with the given label."
	| suspendingList |
	suspendingList _ activeProcess suspendingList.
	suspendingList == nil
		ifTrue: [activeProcess == Processor activeProcess
					ifTrue: [activeProcess suspend]]
		ifFalse: [suspendingList remove: activeProcess.
				activeProcess offList].

	Debugger openInterrupt: labelString
			onProcess: activeProcess