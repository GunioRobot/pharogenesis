yScrollBarValue: scrollValue
	scroller hasSubmorphs ifFalse: [^ self].
	scroller offset: scroller offset x @ (self totalScrollRange y * scrollValue)