xScrollBarValue: scrollValue 
	scroller hasSubmorphs ifFalse: [^ self].
	scroller offset: self totalScrollRange x * scrollValue @ scroller offset y