newTextMorph
	"Create a new, empty TextMorph that can be placed in this book."

	self isInWorld ifTrue:
		[self primaryHand attachMorph:
			(TextMorph new extent: currentPage width@30)].
