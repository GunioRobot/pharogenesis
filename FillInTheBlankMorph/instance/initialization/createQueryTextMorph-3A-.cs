createQueryTextMorph: queryString 
	"create the queryTextMorph"
	| result frame |
	result := TextMorph new contents: queryString.
	result setNameTo: 'query' translated.
	result lock.
	frame := LayoutFrame new.
	frame topFraction: 0.0;
		 topOffset: 2.
	frame leftFraction: 0.5;
		 leftOffset: (result width // 2) negated.
	result layoutFrame: frame.
	self addMorph: result.
	^ result