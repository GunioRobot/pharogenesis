addMorphicStatusPaneTo: row from: views at: innerFractions plus: verticalOffset 
	| delta statusFractions outputBoxFractions |
	delta _ 20.
	statusFractions _ innerFractions withRight: 0.5.
	outputBoxFractions _ (statusFractions withLeft: 0.5)
				withRight: 1.
	row
		addMorph: (views at: #status)
		fullFrame: (LayoutFrame
				fractions: statusFractions
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset + delta))).
	row
		addMorph: (views at: #outBoxStatus)
		fullFrame: (LayoutFrame
				fractions: outputBoxFractions
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset + delta))).
	^ verticalOffset + delta