commandTiles
	"Return a list of tiles for my scriptedPlayer's commands."

	| resultType cmd m argType argTile selfTile aRow names bank  |

	names _ scriptedPlayer class namedTileScriptSelectors.
	bank _ self scriptsBank.
	^ (scriptedPlayer typedCommandsForBank: bank) collect: [:entry |
		aRow _ PartsBinMorph newRow borderWidth: 0;
			color: self color.
		resultType _ (entry at: 1).
		cmd _ (entry at: 2).
		entry size = 2
			ifTrue:
				[m _ PhraseTileMorph new setOperator: cmd
					type: resultType
					rcvrType: #player.
				(names includes: cmd) ifTrue: [m userScriptSelector: cmd]]
			ifFalse: 
				[argType _ entry at: 3.
				m _ PhraseTileMorph new setOperator: cmd
					type: resultType
					rcvrType: #player
					argType: argType.
				argTile _ self tileForArgType: argType.
				argTile position: m lastSubmorph position.
				m lastSubmorph addMorph: argTile.
				m markAsPartsDonor].
		selfTile _ self tileForSelf.
		selfTile position: m firstSubmorph position.
		m firstSubmorph addMorph: selfTile.
	
		aRow addMorph: (ScriptingSystem tryButtonFor: m).
		aRow addMorphBack: (Morph new extent: 4@2; color: self color).
		aRow addMorphBack: m.
		aRow beSticky; openToDragNDrop: false.

		aRow]


	"	m addMorphFront: (Morph new color: self color; extent: 2@10). "