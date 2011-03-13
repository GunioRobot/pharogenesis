buildMVCOptionalButtonsButtonsView

	| aView bHeight offset aButtonView wid pairs windowWidth previousView |
	aView := View new model: self.
	bHeight := self optionalButtonHeight.
	windowWidth := 150.
	aView window: (0@0 extent: windowWidth@bHeight).
	offset := 0.
	pairs := self optionalButtonPairs.
	previousView := nil.
	pairs do: [:pair |
		aButtonView := PluggableButtonView on: self getState: nil action: pair second.
		pair second = pairs last second
			ifTrue:
				[wid := windowWidth - offset]
			ifFalse:
				[aButtonView borderWidthLeft: 0 right: 1 top: 0 bottom: 0.
				wid := windowWidth // (pairs size)].
		aButtonView
			label: pair first asParagraph;
			insideColor: Color red muchLighter lighter;
			window: (offset@0 extent: wid@bHeight).
		offset := offset + wid.
		pair second = pairs first second
			ifTrue: [aView addSubView: aButtonView]
			ifFalse: [aView addSubView: aButtonView toRightOf: previousView].
		previousView := aButtonView].
	^ aView