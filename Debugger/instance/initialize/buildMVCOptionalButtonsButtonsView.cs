buildMVCOptionalButtonsButtonsView

	| aView bHeight offset aButtonView wid pairs windowWidth previousView |
	aView _ View new model: self.
	bHeight _ self optionalButtonHeight.
	windowWidth _ 150.
	aView window: (0@0 extent: windowWidth@bHeight).
	offset _ 0.
	pairs _ self optionalButtonPairs.
	previousView _ nil.
	pairs do: [:pair |
		aButtonView _ PluggableButtonView on: self getState: nil action: pair second.
		pair second = pairs last second
			ifTrue:
				[wid _ windowWidth - offset]
			ifFalse:
				[aButtonView borderWidthLeft: 0 right: 1 top: 0 bottom: 0.
				wid _ windowWidth // (pairs size)].
		aButtonView
			label: pair first asParagraph;
			insideColor: Color red muchLighter lighter;
			window: (offset@0 extent: wid@bHeight).
		offset _ offset + wid.
		pair second = pairs first second
			ifTrue: [aView addSubView: aButtonView]
			ifFalse: [aView addSubView: aButtonView toRightOf: previousView].
		previousView _ aButtonView].
	^ aView