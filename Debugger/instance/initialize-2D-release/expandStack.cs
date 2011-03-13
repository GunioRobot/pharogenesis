expandStack
	"This initialization occurs when the interrupted context is to modelled by 
	a DebuggerView, rather than a NotifierView (which can not display 
	more than five message-sends."

	self newStack: (contextStackTop stackOfSize: 7).
	contextStackIndex _ 0.
	receiverInspector _ Inspector inspect: nil.
	contextVariablesInspector _ ContextVariablesInspector inspect: nil.
	proceedValue _ nil