paintMode
	| temp clickedActor |
	self mode: #paint.

	temp _ myCamera pickObjectAndVertexAt: Sensor cursorPoint.
	clickedActor _ temp key.

	backup _ clickedActor getTexturePointer deepCopy.

	palette _ self world paintBox.
	palette position: self position + (self extent x @ 0); focusMorph: self.