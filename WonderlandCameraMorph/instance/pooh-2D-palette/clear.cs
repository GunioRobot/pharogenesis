clear
	currentActor ifNotNil: [
		currentActor setTexturePointer: ((Form extent: 256@128 depth: Display depth) fillColor: Color white) asTexture]
