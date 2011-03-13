universalTilesForGetterOf: aMethodInterface
	"Return universal tiles for a getter on the given method interface."

	| ms argTile argArray itsSelector |
	itsSelector _ aMethodInterface selector.
	argArray _ #().

	"Four gratuituous special cases..."

	(itsSelector == #color:sees:) ifTrue:
		[argTile _ ScriptingSystem tileForArgType: #Color.
		argArray _ Array with: argTile colorSwatch color with: argTile colorSwatch color copy].

	itsSelector == #seesColor: ifTrue:
		[argTile _ ScriptingSystem tileForArgType: #Color.
		argArray _  Array with: argTile colorSwatch color].

	(#(touchesA: overlaps: overlapsAny:) includes: itsSelector) ifTrue:
		[argTile _ ScriptingSystem tileForArgType: #Player.
		argArray _ Array with: argTile actualObject].

	ms _ MessageSend receiver: self selector: itsSelector arguments: argArray.
	^ ms asTilesIn: self class globalNames: (self class officialClass ~~ CardPlayer)
			"For CardPlayers, use 'self'.  For others, name it, and use its name."