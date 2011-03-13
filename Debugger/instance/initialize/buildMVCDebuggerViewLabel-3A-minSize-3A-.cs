buildMVCDebuggerViewLabel: aString minSize: aPoint
	"Build an MVC debugger view around the receiver, and return the StandardSystemView thus created."

	| topView stackListView stackCodeView rcvrVarView rcvrValView ctxtVarView ctxtValView deltaY underPane annotationPane buttonsView oldContextStackIndex |

	oldContextStackIndex := contextStackIndex.
	self expandStack. "Sets contextStackIndex to zero."
	contextStackIndex := oldContextStackIndex.

	topView := StandardSystemView new model: self.
	topView borderWidth: 1.
	stackListView := PluggableListView on: self
			list: #contextStackList
			selected: #contextStackIndex
			changeSelected: #toggleContextStackIndex:
			menu: #contextStackMenu:shifted:
			keystroke: #contextStackKey:from:.
		stackListView menuTitleSelector: #messageListSelectorTitle.
		stackListView window: (0 @ 0 extent: 150 @ 50).
		topView addSubView: stackListView.
	deltaY := 0.
	 self wantsAnnotationPane
		ifTrue:
			[annotationPane := PluggableTextView on: self
				text: #annotation accept: nil readSelection: nil menu: nil.
			annotationPane window: (0@0 extent: 150@self optionalAnnotationHeight).
			topView addSubView: annotationPane below: stackListView.
			deltaY := deltaY + self optionalAnnotationHeight.
			underPane := annotationPane]
		ifFalse:
			[underPane := stackListView].
	self wantsOptionalButtons
		ifTrue:
			[buttonsView := self buildMVCOptionalButtonsButtonsView.
			buttonsView borderWidth: 1.
			topView addSubView: buttonsView below: underPane.
			underPane := buttonsView.
			deltaY := deltaY + self optionalButtonHeight].
	stackCodeView := PluggableTextView on: self
			text: #contents accept: #contents:notifying:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		stackCodeView window: (0 @ 0 extent: 150 @ (75 - deltaY)).
		topView addSubView: stackCodeView below: underPane.
	rcvrVarView := PluggableListView on: self receiverInspector
			list: #fieldList
			selected: #selectionIndex
			changeSelected: #toggleIndex:
			menu: #fieldListMenu:
			keystroke: #inspectorKey:from:.
		rcvrVarView window: (0 @ 0 extent: 25 @ (50 - deltaY)).
		topView addSubView: rcvrVarView below: stackCodeView.
	rcvrValView := PluggableTextView on: self receiverInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		rcvrValView window: (0 @ 0 extent: 50 @ (50 - deltaY)).
		topView addSubView: rcvrValView toRightOf: rcvrVarView.
	ctxtVarView := PluggableListView on: self contextVariablesInspector
			list: #fieldList
			selected: #selectionIndex
			changeSelected: #toggleIndex:
			menu: #fieldListMenu:
			keystroke: #inspectorKey:from:.
		ctxtVarView window: (0 @ 0 extent: 25 @ (50 - deltaY)).
		topView addSubView: ctxtVarView toRightOf: rcvrValView.
	ctxtValView := PluggableTextView on: self contextVariablesInspector
			text: #contents accept: #accept:
			readSelection: #contentsSelection menu: #codePaneMenu:shifted:.
		ctxtValView window: (0 @ 0 extent: 50 @ (50 - deltaY)).
		topView addSubView: ctxtValView toRightOf: ctxtVarView.
	topView label: aString.
	topView minimumSize: aPoint.
	^ topView