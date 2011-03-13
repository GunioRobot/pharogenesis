buildMVCDebuggerViewLabel: aString minSize: aPoint

	| topView stackListView stackCodeView rcvrVarView rcvrValView ctxtVarView ctxtValView |
	self expandStack.
	topView _ StandardSystemView new model: self.
	topView borderWidth: 1.
	stackListView _ PluggableListView on: self
			list: #contextStackList
			selected: #contextStackIndex
			changeSelected: #toggleContextStackIndex:
			menu: #contextStackMenu:shifted:
			keystroke: #contextStackKey:from:.
		stackListView window: (0 @ 0 extent: 150 @ 50).
		topView addSubView: stackListView.
	stackCodeView _ PluggableTextView on: self
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		stackCodeView window: (0 @ 0 extent: 150 @ 75).
		topView addSubView: stackCodeView below: stackListView.
	rcvrVarView _ PluggableListView on: self receiverInspector
			list: #fieldList
			selected: #selectionIndex
			changeSelected: #toggleIndex:
			menu: #fieldListMenu:
			keystroke: #inspectorKey:from:.
		rcvrVarView window: (0 @ 0 extent: 25 @ 50).
		topView addSubView: rcvrVarView below: stackCodeView.
	rcvrValView _ PluggableTextView on: self receiverInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		rcvrValView window: (0 @ 0 extent: 50 @ 50).
		topView addSubView: rcvrValView toRightOf: rcvrVarView.
	ctxtVarView _ PluggableListView on: self contextVariablesInspector
			list: #fieldList
			selected: #selectionIndex
			changeSelected: #toggleIndex:
			menu: #fieldListMenu:
			keystroke: #inspectorKey:from:.
		ctxtVarView window: (0 @ 0 extent: 25 @ 50).
		topView addSubView: ctxtVarView toRightOf: rcvrValView.
	ctxtValView _ PluggableTextView on: self contextVariablesInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		ctxtValView window: (0 @ 0 extent: 50 @ 50).
		topView addSubView: ctxtValView toRightOf: ctxtVarView.
	topView label: aString.
	topView minimumSize: aPoint.
	^ topView
