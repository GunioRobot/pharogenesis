cannotReturn: result
	"The receiver tried to return result to a method context that no longer exists."

	DebuggerView
		openContext: thisContext
		label: 'Block cannot return'
		contents: thisContext shortStack.
