openFullNoSuspendLabel: aString
	"Create and schedule a full debugger with the given label. Do not terminate the current active process."

	| topView |
	topView _ self buildMVCDebuggerViewLabel: aString minSize: 300@200.
	topView controller openNoTerminate.
	^ topView
