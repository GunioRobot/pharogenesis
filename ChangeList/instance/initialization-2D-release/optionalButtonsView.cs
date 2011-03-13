optionalButtonsView
	"Answer the a View containing the optional buttons"

	| view bHeight vWidth first offset previousView bWidth button |
	vWidth := 200.
	bHeight := self optionalButtonHeight.
	previousView := nil.
	offset := 0.
	first := true.

	view := View new
		model: self;
		window: (0 @ 0 extent: vWidth @ bHeight).

	self changeListButtonSpecs do: [:triplet |
		button := PluggableButtonView
			on: self
			getState: nil
			action: triplet second.
		button label: triplet first asParagraph.
		bWidth := button label boundingBox width // 2.
		button
			window: (offset@0 extent: bWidth@bHeight);
			borderWidthLeft: 0 right: 1 top: 0 bottom: 0.
		offset := offset + bWidth.
		first
			ifTrue:
				[view addSubView: button.
				first := false.]
			ifFalse:
				[view addSubView: button toRightOf: previousView].
		previousView := button].

	button := PluggableButtonView
		on: self
		getState: #showingAnyKindOfDiffs
		action: #toggleDiffing.
	button
		label: 'diffs' asParagraph;
		window: (offset@0 extent: (vWidth - offset)@bHeight).
	view addSubView: button toRightOf: previousView.

	^ view