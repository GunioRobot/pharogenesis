destroy: aDuration
	"Implements the animated destroy of an actor.  This takes all the actors parts and spins them off in an arbitrary direction"

	| anim allAnims undoActions childList partsList |

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for destroying ' , myName , ' because ', msg.
			^ nil ].

	"The parameter checks out, so start the setup"
	undoActions _ OrderedCollection new.
	allAnims _ OrderedCollection new.
	childList _ self getAllChildren.
	partsList _ self getAllParts.
	partsList addFirst: self.

	"Do it for the top level object"

	"We need to do this for every part"
	childList do: [:child |
		(child isPart)
			ifTrue: [

				"Make sure our POV gets reset on undo"
				undoActions addFirst: (UndoPOVChange for: child from: (child getPointOfView)).
				
				"Create the animation for moving toward a random endpoint"
				anim _ child moveTo: { (-2 to: 2) atRandom. (-2 to: 2) atRandom.
							(-2 to: 2) atRandom} duration: aDuration
							asSeenBy: (myWonderland getScene) style: abruptly.

				anim stop.
				anim setUndoable: false.
				allAnims addLast: anim.

				"Create the animation for spinning this object"
				child turnToRightNow: { (0 to: 360) atRandom. (0 to: 360) atRandom.
							(0 to: 360) atRandom} undoable: false.

				anim _ child turn: left turns: aDuration speed: 1.
				anim stop.
				anim setUndoable: false.
				allAnims addLast: anim.
					]
			ifFalse: [
				"Make the non-part children point to this actor's parent"
				undoActions addLast: (UndoParentChange newFor: child from: (child getParent)).
				child reparentTo: (self getParent).
					].
					].

	"Add an undo action to put the objects back in the scene"	
	undoActions addFirst: (UndoAction new: [ (myWonderland getScene) addChild: self.
											 myWonderland getEditor updateActorBrowser ]).

	"Add the undo list to the stack"
	(myWonderland getUndoStack) push: (UndoChangeList new setChangeList: undoActions).

	"Create the animation to remove the parts from the scene and update the actor browser"
	anim _ self do: [ self removeFromScene.
					 myWonderland getEditor updateActorBrowser ].

	"Now start our parallel animation"
	anim _ myWonderland doInOrder: { myWonderland doTogether: allAnims. anim }.
	anim setUndoable: false.
