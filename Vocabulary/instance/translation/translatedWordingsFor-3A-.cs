translatedWordingsFor: symbolList
	"Answer a list giving the translated wordings for the input list. Caveat: at present, this mechanism is only germane for *categories*"

	^ symbolList collect: [:sym | self translatedWordingFor: sym]
