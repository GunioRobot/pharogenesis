interruptName: labelString
	"Create a Notifier on the active scheduling process with the given label. Make the Notifier the active controller."

	^ self interruptName: labelString preemptedProcess: nil
