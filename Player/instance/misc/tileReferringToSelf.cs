tileReferringToSelf
	"answer a tile that refers to the receiver"

	| aTile  nn tile |
	Preferences universalTiles ifTrue:
		[nn _ self externalName. 	"name it, if necessary, and put in References"
		(References includesKey: nn asSymbol) ifFalse: [
			 References at: nn asSymbol put: self].
		tile _ SyntaxMorph new parseNode: 
			(VariableNode new name: nn key: nn code: nil).
		tile layoutInset: 1; addMorph: (tile addString: nn special: false).
		tile color: (SyntaxMorph translateColor: #variable).
		tile extent: tile firstSubmorph extent + (2@2).
		^ tile].

	aTile _ TileMorph new setToReferTo: self.
	^ aTile