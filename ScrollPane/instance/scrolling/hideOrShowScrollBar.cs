hideOrShowScrollBar
	"Hide or show the scrollbar depending on if the pane is scrolled/scrollable."

	"Don't do anything with the retractable scrollbar unless we have focus"
	retractableScrollBar & self hasFocus not ifTrue: [^self].

	self isScrollable not & self isScrolledFromTop not ifTrue: [self hideScrollBar].
	self isScrollable | self isScrolledFromTop ifTrue: [self showScrollBar].
