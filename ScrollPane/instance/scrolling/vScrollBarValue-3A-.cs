vScrollBarValue: scrollValue
	scroller hasSubmorphs ifFalse: [^ self].
	scroller offset: (scroller offset x @ (self vLeftoverScrollRange * scrollValue) rounded)
