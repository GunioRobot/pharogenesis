scrollBarValue: scrollValue
	scroller hasSubmorphs ifFalse: [^ self].
	scroller offset: -3 @ (self totalScrollRange * scrollValue)