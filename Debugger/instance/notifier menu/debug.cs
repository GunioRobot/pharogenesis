debug
	"Open a full DebuggerView."
	| topView |
	topView _ self topView.
	topView model: nil.  "so close won't release me."
	Smalltalk isMorphic
		ifTrue:
			[self breakDependents.
			topView delete.
			^ self openFullMorphicLabel: topView label].

	topView controller controlTerminate.
	topView deEmphasize; erase.

	"a few hacks to get the scroll selection artifacts out when we got here by clicking in the list"
	topView subViewWantingControl ifNotNil: [
		topView subViewWantingControl controller controlTerminate
	].
	topView controller status: #closed.

	self openFullNoSuspendLabel: topView label.
	topView controller closeAndUnscheduleNoErase.
	Processor terminateActive.
