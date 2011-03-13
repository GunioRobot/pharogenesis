wrap

	| myBox box newX newY wrapped |
	owner ifNil: [^ self].
	myBox _ self fullBounds.
	box _ owner bounds.
	newX _ self position x.
	newY _ self position y.
	wrapped _ false.
	((myBox right < box left) or: [myBox left > box right]) ifTrue: [
		newX _ box left + ((self position x - box left) \\ box width).
		wrapped _ true].
	((myBox bottom < box top) or: [myBox top > box bottom]) ifTrue: [
		newY _ box top + ((self position y - box top) \\ box height).
		wrapped _ true].
	self position: newX@newY.
	(wrapped and: [owner isPlayfieldLike])
		ifTrue: [owner changed].  "redraw all turtle trails if wrapped"

