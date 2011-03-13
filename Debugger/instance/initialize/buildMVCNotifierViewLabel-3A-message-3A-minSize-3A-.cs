buildMVCNotifierViewLabel: aString message: messageString minSize: aPoint

	| topView aStringHolderView |
	topView _ StandardSystemView new model: self.
	topView borderWidth: 1.
	aStringHolderView _ PluggableTextView on: self
		text: #contents
		accept: #doNothing:
		readSelection: #contentsSelection
		menu: #debugProceedMenu:.
	aStringHolderView
		editString: messageString;
		askBeforeDiscardingEdits: false.
	topView
		addSubView: aStringHolderView;
		label: aString;
		minimumSize: aPoint.
	^ topView
