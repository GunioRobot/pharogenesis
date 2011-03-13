addMorphicStatusPaneTo: row from: views at: innerFractions plus: verticalOffset 
	| delta |
	delta _ 20.
	row
		addMorph: (views at: #status)
		fullFrame: (LayoutFrame
				fractions: innerFractions
				offsets: (0 @ verticalOffset corner: 0 @ (verticalOffset + delta))).
	^ verticalOffset + delta