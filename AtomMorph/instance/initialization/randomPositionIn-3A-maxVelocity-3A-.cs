randomPositionIn: aRectangle maxVelocity: maxVelocity
	"Give this atom a random position and velocity."

	| origin extent |
	origin _ aRectangle origin.
	extent _ (aRectangle extent - self bounds extent) rounded.
	self position:
		(origin x + extent x atRandom) @
		(origin y + extent y atRandom).
	velocity _
		(maxVelocity - (2 * maxVelocity) atRandom) @
		(maxVelocity - (2 * maxVelocity) atRandom).
