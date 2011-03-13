onTicksSelector
	"Cache the interned symbol.  Should intern: do this?"

	clan = ClanCache ifTrue: [^ OnTicksSelectorCache].
	ClanCache _ clan.
	^ OnTicksSelectorCache _ (self nameInModel, 'OnTicks:') asSymbol
