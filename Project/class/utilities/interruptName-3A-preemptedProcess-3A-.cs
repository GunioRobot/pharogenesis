interruptName: labelString preemptedProcess: theInterruptedProcess
	"Create a Notifier on the active scheduling process with the given label."
	| preemptedProcess projectProcess suspendingList |
	Smalltalk isMorphic ifFalse:
		[^ ScheduledControllers interruptName: labelString].
	ActiveHand ifNotNil:[ActiveHand interrupted].
	ActiveWorld _ World. "reinstall active globals"
	ActiveHand _ World primaryHand.
	ActiveHand interrupted. "make sure this one's interrupted too"
	ActiveEvent _ nil.

	projectProcess _ self uiProcess.	"we still need the accessor for a while"
	preemptedProcess _ theInterruptedProcess ifNil: [Processor preemptedProcess].
	"Only debug preempted process if its priority is >= projectProcess' priority"
	preemptedProcess priority < projectProcess priority ifTrue:[
		(suspendingList _ projectProcess suspendingList) == nil
			ifTrue: [projectProcess == Processor activeProcess
						ifTrue: [projectProcess suspend]]
			ifFalse: [suspendingList remove: projectProcess ifAbsent: [].
					projectProcess offList].
		preemptedProcess _ projectProcess.
	] ifFalse:[
		preemptedProcess suspend offList.
	].
	Debugger openInterrupt: labelString onProcess: preemptedProcess
