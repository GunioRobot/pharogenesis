handUserParameterTile
	"Hand the user a parameter, presumably to drop in the script"
	
	| aTileMorph |
	aTileMorph _ ParameterTile new forScriptEditor: self.
	self currentHand attachMorph: aTileMorph