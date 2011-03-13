bestGuessOfCurrentWorld
	"Return world I am in, or current world if none."

	^ self world ifNil: [Display bestGuessOfCurrentWorld]
	