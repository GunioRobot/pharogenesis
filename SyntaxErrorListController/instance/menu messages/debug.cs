debug
	"Show the stack of how we got to this syntax editor -- Compiler called from FileIn, etc.."

	self controlTerminate.
	DebuggerView openDebugger: model debugger label: 'Stack of the Syntax Error' .
	self controlInitialize