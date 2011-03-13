interruptName: labelString
	"Create a Notifier on the active scheduling process with the given label."
	| suspendingList projectProcess |
	Smalltalk isMorphic ifFalse:
		[^ ScheduledControllers interruptName: labelString].

	World primaryHand ifNotNil: [World primaryHand releaseAllFoci].

	projectProcess _ self uiProcess.	"we still need the accessor for a while"
	(suspendingList _ projectProcess suspendingList) == nil
		ifTrue: [projectProcess == Processor activeProcess
					ifTrue: [projectProcess suspend]]
		ifFalse: [suspendingList remove: projectProcess.
				projectProcess offList].

	Debugger openInterrupt: labelString onProcess: projectProcess
