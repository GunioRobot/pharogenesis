becomeChildOf: anObject
	"Update the undo stack and make this actor a child of the specified object."

	| oldParent |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyReferenceFrame: anObject ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak can only make ' , myName , ' a child of other actors or the scene, and ', msg.
			^ nil ].

	(self == anObject) ifTrue: [
		myWonderland reportErrorToUser: 'Squeak can not make ' , myName , ' a child of itself.'.
		^ nil ].
		
	oldParent _ myParent.

	(myWonderland getUndoStack) push: (UndoAction new: [self reparentTo: oldParent]).

	self reparentTo: anObject.
