sliderParameters
	"Answer a list of parameters that the user can change via a slider. Each parameter is described by an array of: <name> <min value> <max value> <balloon help string>."

	^ super sliderParameters, #(
		(dyeCount 50 1000 'The number of dye particles.')
		(waterCount 100 4000 'The number of water particles.'))
