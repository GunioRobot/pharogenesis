imagePatch
	^ imagePatch ifNil: [imagePatch _ self packageSnapshot patchRelativeToBase: self ancestorSnapshot]