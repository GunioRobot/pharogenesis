buildMVCNotifierViewLabel: aString message: messageString minSize: aPoint

	| topView aStringHolderView buttonView x y bHeight |
	topView _ StandardSystemView new model: self.
	topView borderWidth: 1.
	buttonView _ self buildMVCNotifierButtonView.
	topView addSubView: buttonView.
	aStringHolderView _ PluggableTextView on: self
		text: #contents
		accept: #doNothing:
		readSelection: #contentsSelection
		menu: #debugProceedMenu:.
	aStringHolderView
		editString: messageString;
		askBeforeDiscardingEdits: false.
	x _ 350 max: (aPoint x).
	y _ ((4 * 15) + 16) max: (aPoint y - 16 - self optionalButtonHeight).
	bHeight _ self optionalButtonHeight.
	y _ y - bHeight.
	aStringHolderView window: (0@0 extent: x@y).
	topView
		addSubView: aStringHolderView below: buttonView;
		label: aString;
		minimumSize: aPoint.
	^ topView