dstScroll: scrollValue
	"Called from dst when scrolled by keyboard etc."

	self scrollbarMorph value: scrollValue.
	self srcMorph vScrollBarValue: scrollValue.
	self updateJoinOffsets