interruptName: labelString
	"Create a Notifier on the active scheduling process with the given label."
	| suspendingList projectProcess |
	Smalltalk isMorphic ifFalse:
		[^ ScheduledControllers interruptName: labelString].

	projectProcess _ Project current activeProcess.
	(suspendingList _ projectProcess suspendingList) == nil
		ifTrue: [projectProcess == Processor activeProcess
					ifTrue: [projectProcess suspend]]
		ifFalse: [suspendingList remove: projectProcess.
				projectProcess offList].

	Debugger openInterrupt: labelString onProcess: projectProcess
