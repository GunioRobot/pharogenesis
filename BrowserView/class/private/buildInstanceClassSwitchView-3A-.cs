buildInstanceClassSwitchView: aBrowser
	| aView aSwitchView |
	aView _ View new model: aBrowser.
	aView window: (0 @ 0 extent: 50 @ 8).
	aView borderWidthLeft: 2 right: 0 top: 0 bottom: 2.
	aSwitchView _ self buildInstanceSwitchView: aBrowser.
	aView
		addSubView: aSwitchView
		align: aSwitchView viewport topLeft
		with: aView window topLeft.
	aSwitchView _ self buildClassSwitchView: aBrowser.
	aView
		addSubView: aSwitchView
		align: aSwitchView viewport topLeft
		with: aView lastSubView viewport topRight.
	^aView