debugger: aDebugger 
	"Answer a DebuggerView whose model is aDebugger. It consists of three 
	subviews, a ContextStackView (the ContextStackListView and 
	ContextStackCodeView), an InspectView of aDebugger's variables, and an 
	InspectView of the variables of the currently selected method context."

	| debuggerView contextStackView contextVariablesView receiverVariablesView |
	aDebugger expandStack.
	debuggerView _ self new model: aDebugger.
	contextStackView _ self buildContextStackView: aDebugger.
	receiverVariablesView _ self buildReceiverVariablesView: aDebugger.
	contextVariablesView _ self buildContextVariablesView: aDebugger.
	debuggerView addSubView: contextStackView.
	debuggerView
		addSubView: receiverVariablesView
		align: receiverVariablesView viewport topLeft
		with: contextStackView viewport bottomLeft.
	debuggerView
		addSubView: contextVariablesView
		align: contextVariablesView viewport topLeft
		with: receiverVariablesView viewport topRight.
	^debuggerView