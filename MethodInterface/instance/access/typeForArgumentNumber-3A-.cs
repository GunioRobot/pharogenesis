typeForArgumentNumber: anArgumentNumber
	"Answer the data type for the given argument number"

	| aVariable |
	aVariable _ self argumentVariables at: anArgumentNumber.
	^ aVariable variableType