hScrollBarValue: scrollValue

	| x |
	self hIsScrollbarShowing ifFalse: 
		[^scroller offset: (0 - self hMargin)@scroller offset y].
	((x _ self hLeftoverScrollRange * scrollValue) <= 0)
		ifTrue:[x _ 0 - self hMargin].
	scroller offset: (x@scroller offset y)
