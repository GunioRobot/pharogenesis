expandStack
	"A Notifier is being turned into a full debugger.  Show a substantial amount of stack in the context pane."

	self newStack: (contextStackTop stackOfSize: 20).
	contextStackIndex := 0.
	receiverInspector := Inspector inspect: nil.
	contextVariablesInspector := ContextVariablesInspector inspect: nil.
	proceedValue := nil