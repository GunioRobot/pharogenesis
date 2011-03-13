goToLastCardInBackground
	"Install the final card in the current background as the current card"

	| kind |
	kind _ currentPage player class baseUniclass.
	self goToCard: (cards reversed detect: [:aCard | aCard isKindOf: kind] ifNone: [^ self beep])