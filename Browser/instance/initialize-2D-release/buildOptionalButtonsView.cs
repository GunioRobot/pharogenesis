buildOptionalButtonsView
	"Build the view for the optional buttons (mvc)"

	| aView buttonView offset bWidth bHeight first previousView |
	aView _ View new model: self.
	bHeight _ self optionalButtonHeight.
	aView window: (0 @ 0 extent: 200 @ bHeight).
	offset _ 0.
	first _ true.
	previousView _ nil.
	self optionalButtonPairs do: [:pair |
		buttonView _ PluggableButtonView on: self
			getState: nil
			action: pair second.
		buttonView
			label: pair first asParagraph.
		bWidth _ buttonView label boundingBox width // 2.  "Need something more deterministic."
		buttonView window: (offset@0 extent: bWidth@bHeight).
		offset _ offset + bWidth + 0.
		first
			ifTrue:
				[aView addSubView: buttonView.
				first _ false]
			ifFalse:
				[buttonView borderWidthLeft: 1 right: 0 top: 0 bottom: 0.
				aView addSubView: buttonView toRightOf: previousView]. 
		previousView _ buttonView].
	^ aView