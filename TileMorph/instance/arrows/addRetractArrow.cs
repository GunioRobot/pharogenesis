addRetractArrow
	"Must be situated in a script"

	self couldRetract ifNil: [^ self].
	retractArrow _ ImageMorph new image: RetractPicture.
	suffixArrow ifNotNil: [
		self addMorph: retractArrow inFrontOf: suffixArrow].
	fullBounds _ nil.
	self extent: self fullBounds extent