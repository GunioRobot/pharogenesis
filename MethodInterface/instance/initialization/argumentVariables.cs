argumentVariables
	"Answer the list of argumentVariables of the interface"

	^ argumentVariables ifNil: [argumentVariables _ OrderedCollection new]