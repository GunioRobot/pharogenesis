migrate
	"Convert this map to 1.1 format and fix other things.

	Fixing the bug from SM1.x with 'Maturity level' and
	'SqueakAmp' sharing the same UUID."

	| cat |
	cat _ (self categories detect: [:c |
			c name = 'Alpha']) parent.
	cat id: (UUID fromString: 'b9f16f16-4a58-0442-9159-041dd7213070').
	objects at: cat id put: cat. "Wasn't in there before"

	self mapInitialsFromMinnow