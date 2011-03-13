addSuffixArrow
	suffixArrow _ ImageMorph new image: SuffixPicture.
	self addMorph: suffixArrow.
	suffixArrow align: suffixArrow topLeft with:
		bounds topRight + (-2@(self height//2)) - (0@(suffixArrow
height//2)).

	self extent: self fullBounds extent