dragMoveFromHalo: evt with: handle
	| morph delta screenPos scenePos |
	morph _ self getCameraMorph.
	morph == nil ifTrue:[^self].
	delta _ (self pointFromWorld: evt cursorPoint - self dragPositionOffset) - self position.
	screenPos _ (myActor getPositionInPixels: morph getCamera) + delta.
	scenePos _ morph getCamera transformScreenPointToScenePoint: screenPos atDepthOf: myActor.
	myActor moveToRightNow: scenePos asSeenBy: (myWonderland getScene) undoable: false.