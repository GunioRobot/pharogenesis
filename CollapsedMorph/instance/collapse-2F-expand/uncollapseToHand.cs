uncollapseToHand
	"Hand the uncollapsedMorph to the user, placing it in her hand, after remembering appropriate state for possible future use"

	| nakedMorph |
	nakedMorph _ uncollapsedMorph.
	uncollapsedMorph _ nil.
	nakedMorph setProperty: #collapsedPosition toValue: self position.
	mustNotClose _ false.  "so the delete will succeed"
	self delete.
	ActiveHand attachMorph: nakedMorph