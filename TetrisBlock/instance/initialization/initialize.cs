initialize
	"initialize the state of the receiver"
	super initialize.
	""
	
	"keep this puppy out of sight"
	shapeInfo _ self class shapeChoices atRandom.
	baseCellNumber _ 4 atRandom + 2 @ 1.
	angle _ 4 atRandom