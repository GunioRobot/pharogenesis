makeCameraNamed: aString parent: parentActor
	"Add a new camera to the Wonderland"
	| newCamera |
	newCamera _ self makeCameraNamed: aString.
	parentActor == nil ifFalse:[
		newCamera reparentTo: parentActor.
		newCamera becomePart].
	^newCamera