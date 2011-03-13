buildOptionalButtonsView
	"Build the view for the optional buttons (mvc)"

	| aView buttonView offset bWidth bHeight first previousView |
	aView := View new model: self.
	bHeight := self optionalButtonHeight.
	aView window: (0 @ 0 extent: 200 @ bHeight).
	offset := 0.
	first := true.
	previousView := nil.
	self optionalButtonPairs do: [:pair |
		buttonView := PluggableButtonView on: self
			getState: nil
			action: pair second.
		buttonView
			label: pair first asParagraph.
		bWidth := buttonView label boundingBox width // 2.  "Need something more deterministic."
		buttonView window: (offset@0 extent: bWidth@bHeight).
		offset := offset + bWidth + 0.
		first
			ifTrue:
				[aView addSubView: buttonView.
				first := false]
			ifFalse:
				[buttonView borderWidthLeft: 1 right: 0 top: 0 bottom: 0.
				aView addSubView: buttonView toRightOf: previousView]. 
		previousView := buttonView].
	^ aView