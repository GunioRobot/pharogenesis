ownerChain
	"Answer a list of objects representing the receiver and all of its owners.   The first element is the receiver, and the last one is typically the world in which the receiver resides"
	| c next |
	c _ OrderedCollection with: self.
	next _ self.
	[(next _ next owner) ~~ nil] whileTrue: [c add: next].
	^ c asArray