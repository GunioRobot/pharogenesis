sliderParameters
	"Answer a list of parameters that the user can change via a slider. Each parameter is described by an array of: <name> <min value> <max value> <balloon help string>."

	^ super sliderParameters, #(
		(antCount 10 500 'The number of ants searching for food.'))
