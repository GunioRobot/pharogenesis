growStartFromHalo: evt with: handle

	self removeAllHandlesBut: handle.
	self growPositionOffset: evt cursorPoint - (self pointInWorld: self bottomRight).
	self undo: UndoSizeChange using: myActor getSize.