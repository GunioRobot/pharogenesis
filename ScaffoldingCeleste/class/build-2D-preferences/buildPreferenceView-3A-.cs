buildPreferenceView: topWindow
	| offset model |
	"Derived from addLowerMorphicViews: views andButtons: buttons to: topWindow offset: offset 
		it is much simpler"
	

	model _ topWindow model.

	offset _0.
	topWindow
		addMorph:  (self buildPreferenceTabbedPalette: model)
		frame: (0 @ offset extent: 1 @ (1 - offset)).

		