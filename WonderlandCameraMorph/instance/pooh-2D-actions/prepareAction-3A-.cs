prepareAction: newEvent
	|  range  |
	currentColor _ palette getColor.
	currentNib _ palette getNib.
	currentActor _ newEvent getActor.
	currentCanvas _ (currentActor getTexturePointer getCanvas).
	range _ currentCanvas extent.
	currentPosition _ newEvent getVertex texCoords * range - (currentNib extent // 2).