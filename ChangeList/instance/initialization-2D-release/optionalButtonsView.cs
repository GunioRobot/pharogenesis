optionalButtonsView
	"Answer the a View containing the optional buttons"

	| view bHeight vWidth first offset previousView bWidth button |
	vWidth _ 200.
	bHeight _ self optionalButtonHeight.
	previousView _ nil.
	offset _ 0.
	first _ true.

	view _ View new
		model: self;
		window: (0 @ 0 extent: vWidth @ bHeight).

	self changeListButtonSpecs do: [:triplet |
		button _ PluggableButtonView
			on: self
			getState: nil
			action: triplet second.
		button label: triplet first asParagraph.
		bWidth _ button label boundingBox width // 2.
		button
			window: (offset@0 extent: bWidth@bHeight);
			borderWidthLeft: 0 right: 1 top: 0 bottom: 0.
		offset _ offset + bWidth.
		first
			ifTrue:
				[view addSubView: button.
				first _ false.]
			ifFalse:
				[view addSubView: button toRightOf: previousView].
		previousView _ button].

	button _ PluggableButtonView
		on: self
		getState: #showDiffs
		action: #toggleDiffing.
	button
		label: 'diffs' asParagraph;
		window: (offset@0 extent: (vWidth - offset)@bHeight).
	view addSubView: button toRightOf: previousView.

	^ view