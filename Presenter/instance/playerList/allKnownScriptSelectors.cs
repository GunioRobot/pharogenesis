allKnownScriptSelectors
	"Answer a list of all the selectors implemented by any user-scripted objected within the scope of the receiver"

	| aSet allUniclasses |
	aSet _ Set with: ('script' translated , '1') asSymbol.
	allUniclasses _ (self presenter allPlayersWithUniclasses collect:
		[:aPlayer | aPlayer class]) asSet.
	allUniclasses do:
		[:aUniclass | aSet addAll: aUniclass namedTileScriptSelectors].
	^ aSet asSortedArray

"ActiveWorld presenter allKnownScriptSelectors"
