buildContextStackView: aDebugger

	| topView bottomView contextStackView |
	topView _ ContextStackListView new.
	topView model: aDebugger.
	topView window: (0 @ 0 extent: self contextStackLeftSize).
	topView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.
	bottomView _ ContextStackCodeView new.
	bottomView model: aDebugger.
	bottomView controller: ContextStackCodeController new.
	bottomView window: (0 @ 0 extent: self contextStackRightSize).
	bottomView borderWidthLeft: 2 right: 2 top: 2 bottom: 0.
	contextStackView _ View new.
	contextStackView addSubView: topView.
	contextStackView
		addSubView: bottomView
		align: bottomView viewport topLeft
		with: topView viewport bottomLeft.
	^contextStackView