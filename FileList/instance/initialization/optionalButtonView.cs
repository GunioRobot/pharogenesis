optionalButtonView

	| aView bHeight windowWidth offset previousView aButtonView wid specs |
	aView _ View new model: self.
	bHeight _ self optionalButtonHeight.
	windowWidth _ 120.
	aView window: (0@0 extent: windowWidth@bHeight).
	offset _ 0.
	specs _ self optionalButtonSpecs copyFrom: 1 to: 6.  "Too cramped for the seventh!"
	previousView _ nil.
	specs do: [:quad |
		aButtonView _ PluggableButtonView on: self getState: (quad third == #none ifTrue: [nil] ifFalse: [quad third]) action: quad second.
		quad second = specs last second
			ifTrue:
				[wid _ windowWidth - offset]
			ifFalse:
				[aButtonView borderWidthLeft: 0 right: 1 top: 0 bottom: 0.
				wid _ (windowWidth // (specs size)) - 2].
		aButtonView
			label: quad first asParagraph;
			window: (offset@0 extent: wid@bHeight).
		offset _ offset + wid.
		quad second = specs first second
			ifTrue: [aView addSubView: aButtonView]
			ifFalse: [aView addSubView: aButtonView toRightOf: previousView].
		previousView _ aButtonView].
	^aView
