loadInitialFrame
	"Force the transformations taking place in the first frame."
	super loadInitialFrame.
	self stepToFrame: 1.
	(self isSpriteHolder and:[self visible]) ifTrue:[self activateSprites: true].