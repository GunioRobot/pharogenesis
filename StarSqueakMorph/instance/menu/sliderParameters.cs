sliderParameters
	"Answer a list of parameters that the user can change via a slider. Each parameter is described by an array of: <name> <min value> <max value> <balloon help string>."

	^ #((evaporationRate 0 40
			'The rate at which chemicals evaporate in this world. Larger numbers give faster evaporation.')
		(diffusionRate 0 5
			'The rate of chemical diffusion. Larger numbers give quicker diffusion.'))
