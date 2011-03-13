buildMVCDebuggerViewLabel: aString minSize: aPoint
	"Build an MVC debugger view around the receiver, and return the StandardSystemView thus created."

	| topView stackListView stackCodeView rcvrVarView rcvrValView ctxtVarView ctxtValView deltaY underPane annotationPane buttonsView oldContextStackIndex |

	oldContextStackIndex _ contextStackIndex.
	self expandStack. "Sets contextStackIndex to zero."
	contextStackIndex _ oldContextStackIndex.

	topView _ StandardSystemView new model: self.
	topView borderWidth: 1.
	stackListView _ PluggableListView on: self
			list: #contextStackList
			selected: #contextStackIndex
			changeSelected: #toggleContextStackIndex:
			menu: #contextStackMenu:shifted:
			keystroke: #contextStackKey:from:.
		stackListView menuTitleSelector: #messageListSelectorTitle.
		stackListView window: (0 @ 0 extent: 150 @ 50).
		topView addSubView: stackListView.
	deltaY _ 0.
	 self wantsAnnotationPane
		ifTrue:
			[annotationPane _ PluggableTextView on: self
				text: #annotation accept: nil readSelection: nil menu: nil.
			annotationPane window: (0@0 extent: 150@self optionalAnnotationHeight).
			topView addSubView: annotationPane below: stackListView.
			deltaY _ deltaY + self optionalAnnotationHeight.
			underPane _ annotationPane]
		ifFalse:
			[underPane _ stackListView].
	self wantsOptionalButtons
		ifTrue:
			[buttonsView _ self buildMVCOptionalButtonsButtonsView.
			buttonsView borderWidth: 1.
			topView addSubView: buttonsView below: underPane.
			underPane _ buttonsView.
			deltaY _ deltaY + self optionalButtonHeight].
	stackCodeView _ PluggableTextView on: self
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		stackCodeView window: (0 @ 0 extent: 150 @ (75 - deltaY)).
		topView addSubView: stackCodeView below: underPane.
	rcvrVarView _ PluggableListView on: self receiverInspector
			list: #fieldList
			selected: #selectionIndex
			changeSelected: #toggleIndex:
			menu: #fieldListMenu:
			keystroke: #inspectorKey:from:.
		rcvrVarView window: (0 @ 0 extent: 25 @ (50 - deltaY)).
		topView addSubView: rcvrVarView below: stackCodeView.
	rcvrValView _ PluggableTextView on: self receiverInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		rcvrValView window: (0 @ 0 extent: 50 @ (50 - deltaY)).
		topView addSubView: rcvrValView toRightOf: rcvrVarView.
	ctxtVarView _ PluggableListView on: self contextVariablesInspector
			list: #fieldList
			selected: #selectionIndex
			changeSelected: #toggleIndex:
			menu: #fieldListMenu:
			keystroke: #inspectorKey:from:.
		ctxtVarView window: (0 @ 0 extent: 25 @ (50 - deltaY)).
		topView addSubView: ctxtVarView toRightOf: rcvrValView.
	ctxtValView _ PluggableTextView on: self contextVariablesInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		ctxtValView window: (0 @ 0 extent: 50 @ (50 - deltaY)).
		topView addSubView: ctxtValView toRightOf: ctxtVarView.
	topView label: aString.
	topView minimumSize: aPoint.
	^ topView