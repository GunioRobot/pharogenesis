hScrollBarValue: scrollValue

	| x |
	self hIsScrollbarShowing ifFalse: 
		[^scroller offset: (0 - self hMargin)@scroller offset y].
	((x := self hLeftoverScrollRange * scrollValue) <= 0)
		ifTrue:[x := 0 - self hMargin].
	scroller offset: (x@scroller offset y)
