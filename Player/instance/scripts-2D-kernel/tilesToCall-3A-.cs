tilesToCall: aMethodInterface
	"Answer a phrase for the non-typed command represented by aMethodInterface."

	| resultType cmd argType argTile selfTile aPhrase balloonTextSelector aDocString universal |
	self class namedTileScriptSelectors.

	resultType _ aMethodInterface resultType.
	cmd _ aMethodInterface selector.
	(universal _ self isUniversalTiles)
		ifTrue:
			[aPhrase _ self universalTilesForInterface: aMethodInterface]
		ifFalse: [cmd numArgs == 0
			ifTrue:
				[aPhrase _ PhraseTileMorph new setOperator: cmd
					type: resultType
					rcvrType: #Player]
			ifFalse:
				["only one arg supported in classic tiles, so if this is fed
				with a selector with > 1 arg, results will be very strange"
				argType _ aMethodInterface typeForArgumentNumber: 1.
				aPhrase _ PhraseTileMorph new setOperator: cmd
					type: resultType
					rcvrType: #Player
					argType: argType.
				argTile _ ScriptingSystem tileForArgType: argType.
				argTile position: aPhrase lastSubmorph position.
				aPhrase lastSubmorph addMorph: argTile]].

	(self slotInfo includesKey: cmd)
		ifTrue: [balloonTextSelector _ #userSlot].

	(self belongsToUniClass and: [self class includesSelector: cmd])
		ifTrue:
			[aDocString _ (self class userScriptForPlayer: self selector: cmd) documentation.
			aDocString
				ifNotNil: [aPhrase submorphs second setBalloonText: aDocString]
				ifNil: [balloonTextSelector _ #userScript]].

	(universal ifTrue: [aPhrase submorphs second] ifFalse: [aPhrase operatorTile]) balloonTextSelector: 
			(balloonTextSelector ifNil: [cmd]).
	universal ifFalse:
		[selfTile _ self tileToRefer.
		selfTile position: aPhrase firstSubmorph position.
		aPhrase firstSubmorph addMorph: selfTile.
		aPhrase makeAllTilesGreen.
		aPhrase justGrabbedFromViewer: false].
	^ aPhrase