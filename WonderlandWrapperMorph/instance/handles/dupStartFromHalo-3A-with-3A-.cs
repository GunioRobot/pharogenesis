dupStartFromHalo: evt with: handle
	| newActor |
	self removeAllHandlesBut: handle.
	newActor _ myWonderland duplicateActor: myActor.
	myActor _ newActor.
	self dragPositionOffset: handle center - self positionInWorld.