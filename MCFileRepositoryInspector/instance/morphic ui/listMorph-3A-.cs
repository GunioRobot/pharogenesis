listMorph: listSymbol
	^(super listMorph: listSymbol)
		highlightSelector: (listSymbol , 'Highlight:with:') asSymbol;
		yourself