dragStartFromHalo: evt with: handle
	self removeAllHandlesBut: handle.
	self dragPositionOffset: handle center - self positionInWorld.
	self undo: UndoPOVChange using: myActor getPointOfView.