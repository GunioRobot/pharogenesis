authoringPrototype
	"Answer a morph representing a prototypical instance of the receiver"

	| aMorph |
	aMorph _ self new.
	aMorph color: Color blue.
	aMorph step.
	^ aMorph