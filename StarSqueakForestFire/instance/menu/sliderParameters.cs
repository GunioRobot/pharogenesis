sliderParameters
	"Answer a list of parameters that the user can change via a slider. Each parameter is described by an array of: <name> <min value> <max value> <balloon help string>."

	^ super sliderParameters, #(
		(treePercentage 0 100 'The probability of that a given patch has a tree.'))
