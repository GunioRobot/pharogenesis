hideOrShowScrollBar
	"Hide or show the scrollbar depending on if the pane is scrolled/scrollable."

	"Don't do anything with the retractable scrollbar unless we have focus"
	retractableScrollBar & self hasFocus not ifTrue: [^self].
	"Don't show it if we were told not to."
	(self valueOfProperty: #noScrollBarPlease ifAbsent: [false]) ifTrue: [^self].

	self vIsScrollable not & self isScrolledFromTop not ifTrue: [self vHideScrollBar].
	self vIsScrollable | self isScrolledFromTop ifTrue: [self vShowScrollBar].
