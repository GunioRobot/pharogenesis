offerVarsMenuFor: aReceiver in: aLexiconModel
	"Offer a menu of tiles for assignment and constants"

	| menu instVarList cls |
	menu _ MenuMorph new addTitle: 'Hand me a tile for...'.
	menu addLine.
	menu add: '(accept method now)' target: aLexiconModel selector: #acceptTiles.
	menu submorphs last color: Color red darker.
	menu addLine.
	menu add: 'new temp variable' target: self selector: #attachTileForCode:nodeType: 
				argumentList: {'| temp | temp'. TempVariableNode}.

	instVarList _ OrderedCollection new.
	cls _ aReceiver class.
	[instVarList addAllFirst: cls instVarNames.
	 cls == aLexiconModel limitClass] whileFalse: [cls _ cls superclass].
	instVarList do: [:nn |
		menu add: nn target: self selector: #instVarTile: argument: nn].
	menu popUpAt: ActiveHand position forHand: ActiveHand in: World.

