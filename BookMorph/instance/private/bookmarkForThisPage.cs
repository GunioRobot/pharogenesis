bookmarkForThisPage

	| b |
	b _ SimpleButtonMorph new target: self.
	b actionSelector: #goToPageMorph:.
	b label: 'Bookmark'.
	b arguments: (Array with: currentPage).
	self primaryHand attachMorph: b
