initialize

	super initialize.
	bounds _ (2@2) negated extent: 1@1.	"keep this puppy out of sight"
	shapeInfo _ self class shapeChoices atRandom.
	baseCellNumber _ (4 atRandom + 2) @ 1.
	angle _ 4 atRandom.
	color _ Tetris colors atRandom.
