goToFirstCardInBackground
	"Install the initial card in the current background as the current card in the stack"

	| kind |
	kind _ currentPage player class baseUniclass.
	self goToCard: (cards detect: [:aCard | aCard isKindOf: kind] ifNone: [^ self beep])