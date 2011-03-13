tileReferringToSelf
	| aTile ww nn tile |

	"universal tiles"
	ww _ costume bestGuessOfCurrentWorld.
	(ww valueOfProperty: #universalTiles ifAbsent: [false]) ifTrue: [
		nn _ self externalName. 	"name it, if necessary, and put in References"
		(References includesKey: nn asSymbol) ifFalse: [
			 References at: nn asSymbol put: self].
		tile _ SyntaxMorph new parseNode: 
			(VariableNode new name: nn key: nn code: nil).
		tile layoutInset: 1; addMorph: (tile addString: nn).
		tile color: (SyntaxMorph translateColor: #variable).
		tile extent: tile firstSubmorph extent + (2@2).
		^ tile].

	aTile _ TileMorph new
		setObjectRef: nil "disused parm" actualObject: self;
		typeColor: (ScriptingSystem colorForType: #player).
	aTile enforceTileColorPolicy.
	^ aTile