buildMVCNotifierButtonView

	| aView bHeight priorButton buttonView |
	aView := View new model: self.
	bHeight := self notifierButtonHeight.
	aView window: (0@0 extent: 350@bHeight).
	priorButton := nil.
	self preDebugButtonQuads do:
		[:aSpec |
			buttonView := PluggableButtonView
				on: self
				getState: nil
				action: aSpec second.
			buttonView
				label: aSpec first;
				insideColor: (Color perform: aSpec third) muchLighter lighter;
				borderWidthLeft: 1 right: 1 top: 0 bottom: 0;
				window: (0@0 extent: 117@bHeight).
			priorButton
				ifNil:
					[aView addSubView: buttonView]
				ifNotNil:
					[aView addSubView: buttonView toRightOf: priorButton].
			priorButton := buttonView].
	^ aView