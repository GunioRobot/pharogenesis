destroy: aDuration
	"Implements the animated destroy of a camera.  Unlike destroy for WonderlandActors, this method merely removes the camera from the scene and removes it render window from the world."

	| lightList childList undoActions |

	undoActions _ OrderedCollection new.
	childList _ self getAllChildren.

	childList do: [:child | 
			(child isFirstClass) ifTrue: [
				"Make the non-part children point to this actor's parent"
				undoActions addLast: (UndoParentChange newFor: child from: (child getParent)).
				child reparentTo: (self getParent).
								  		].
				].

	self removeFromScene.

	lightList _ myWonderland getLights.
	lightList remove: self.

	undoActions addLast: (UndoAction new: [ (myWonderland getScene) addChild: self.
									lightList addLast: self ]).

	(myWonderland getUndoStack) push: (UndoChangeList new setChangeList: undoActions).

				


