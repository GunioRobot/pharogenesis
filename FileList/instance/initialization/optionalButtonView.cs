optionalButtonView
	"Answer a view of optional buttons"

	| aView bHeight windowWidth offset previousView aButtonView wid services sel allServices |
	aView _ View new model: self.
	bHeight _ self optionalButtonHeight.
	windowWidth _ 120.
	aView window: (0 @ 0 extent: windowWidth @ bHeight).
	offset _ 0.
	allServices _ self universalButtonServices.
	services _ allServices copyFrom: 1 to: (allServices size min: 5).
	previousView _ nil.
	services
		do: [:service | sel _ service selector.
		aButtonView _ sel asString numArgs = 0
			ifTrue: [PluggableButtonView
					on: service provider
					getState: (service extraSelector == #none
							ifFalse: [service extraSelector])
					action: sel]
			ifFalse: [PluggableButtonView
					on: service provider
					getState: (service extraSelector == #none
							ifFalse: [service extraSelector])
					action: sel
					getArguments: #fullName
					from: self].
		service selector = services last selector
			ifTrue: [wid _ windowWidth - offset]
			ifFalse: [aButtonView
					borderWidthLeft: 0
					right: 1
					top: 0
					bottom: 0.
				wid _ windowWidth // services size - 2].
		aButtonView label: service buttonLabel asParagraph;
			window: (offset @ 0 extent: wid @ bHeight).
		offset _ offset + wid.
		service selector = services first selector
			ifTrue: [aView addSubView: aButtonView]
			ifFalse: [aView addSubView: aButtonView toRightOf: previousView].
		previousView _ aButtonView].
	^ aView