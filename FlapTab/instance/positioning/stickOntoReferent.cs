stickOntoReferent
	"Place the receiver directly onto the referent -- for use when the referent is being shown as a flap"
	| newPosition |
	referent addMorph: self.
	edgeToAdhereTo == #left
		ifTrue:
			[newPosition _ (referent width - self width) @ self top].
	edgeToAdhereTo == #right
		ifTrue:
			[newPosition _ (referent left @ self top)].
	edgeToAdhereTo == #top
		ifTrue:
			[newPosition _ self left @ (referent height - self height)].
	edgeToAdhereTo == #bottom
		ifTrue:
			[newPosition _ self left @ referent top].
	self position: newPosition