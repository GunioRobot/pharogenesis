debugger: aDebugger 
	"Answer a DebuggerView whose model is aDebugger. It consists of three 
	subviews, a ContextStackView (the ContextStackListView and 
	ContextStackCodeView), an InspectView of aDebugger's variables, and an 
	InspectView of the variables of the currently selected method context."
	| topView stackListView stackCodeView rcvrVarView rcvrValView ctxtVarView ctxtValView |
	aDebugger expandStack.
	topView _ self new model: aDebugger.
	stackListView _ ContextStackListView new model: aDebugger.
		stackListView window: (0 @ 0 extent: 150 @ 50).
		stackListView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.
		topView addSubView: stackListView.
	stackCodeView _ ContextStackCodeView new model: aDebugger.
		stackCodeView controller: ContextStackCodeController new.
		stackCodeView window: (0 @ 0 extent: 150 @ 75).
		stackCodeView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.
		topView addSubView: stackCodeView below: stackListView.
	rcvrVarView _ InspectListView new model: aDebugger receiverInspector.
		rcvrVarView window: (0 @ 0 extent: 25 @ 50).
		rcvrVarView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
		topView addSubView: rcvrVarView below: stackCodeView.
	rcvrValView _ InspectCodeView new model: aDebugger receiverInspector.
		rcvrValView window: (0 @ 0 extent: 50 @ 50).
		rcvrValView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
		topView addSubView: rcvrValView toRightOf: rcvrVarView.
	ctxtVarView _ InspectListView new model: aDebugger contextVariablesInspector.
		ctxtVarView window: (0 @ 0 extent: 25 @ 50).
		ctxtVarView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
		topView addSubView: ctxtVarView toRightOf: rcvrValView.
	ctxtValView _ InspectCodeView new model: aDebugger contextVariablesInspector.
		ctxtValView window: (0 @ 0 extent: 50 @ 50).
		ctxtValView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
		topView addSubView: ctxtValView toRightOf: ctxtVarView.
	^ topView