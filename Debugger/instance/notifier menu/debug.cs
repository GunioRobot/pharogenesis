debug
	"Open a full DebuggerView."
	| topView |
	topView _ self topView.
	topView model: nil.  "so close won't release me."
	World ifNotNil:
		[self openFullMorphicLabel: topView label.
		^ topView delete].
	topView controller controlTerminate.
	topView deEmphasizeView; erase.
	self openFullNoSuspendLabel: topView label.
	topView controller closeAndUnscheduleNoErase.
	Processor terminateActive.
