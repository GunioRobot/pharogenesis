optionalButtonsView

	| view bHeight vWidth offset specs previousView button wid buttonCount |
	view _ View new model: self.
	bHeight _ self optionalButtonHeight.
	vWidth _ 180.
	view window: (0@0 extent: vWidth@bHeight).
	offset _ 0.
	specs _ self changeListButtonSpecs.
	buttonCount _ specs size + 1.
	previousView _ nil.
	wid _ vWidth // buttonCount.
	specs do: [:triplet |
		button _ PluggableButtonView on: self getState: nil action: triplet second.
		button
			label: triplet first asParagraph;
			insideColor: Color lightBlue;
			borderWidthLeft: 0 right: 1 top: 0 bottom: 0;
			window: (offset@0 extent: wid@bHeight).
		offset _ offset + wid.
		triplet last = specs first last
			ifTrue: [view addSubView: button]
			ifFalse: [view addSubView: button toRightOf: previousView].
		previousView _ button].
	button _ PluggableButtonView on: self getState: #showDiffs action: #toggleDiff.
	button
		label: 'toggle diff' asParagraph;
		insideColor: Color lightBlue;
		window: (offset@0 extent: (vWidth - offset)@bHeight).
	view addSubView: button toRightOf: previousView.
	^view