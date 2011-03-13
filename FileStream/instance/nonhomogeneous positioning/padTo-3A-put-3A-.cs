padTo: bsize put: aCharacter 
	"Refer to the comment in ExternalStream|padTo:put:."
	| rem |
	rem _ bsize - (self position \\ bsize).
	rem = bsize ifTrue: [^ 0].
	self next: rem put: aCharacter.
	^rem