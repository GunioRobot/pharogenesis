createHierarchy
	"Create a wrapper hierarchy representing the owners of the receiver"
	| actor wrapper |
	actor _ myActor getParent.
	actor == myWonderland getScene ifTrue:[^self]. "At top"
	"Create new wrapper"
	wrapper _ self class on: actor.
	wrapper addMorphFront: self.
	"And continue there"
	^wrapper createHierarchy