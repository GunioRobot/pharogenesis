preserveStateDuring: aBlock
	| retval saveClip saveTransform |
	target preserveStateDuring: [ :innerTarget |
		saveClip _ clipRect.
		saveTransform _ currentTransformation.
		gstateStack addLast: currentFont.
		gstateStack addLast: currentColor.
		gstateStack addLast: shadowColor.
		retval _ aBlock value: self.
		shadowColor _ gstateStack removeLast.
		currentColor _ gstateStack removeLast.
		currentFont _ gstateStack removeLast.
		clipRect _ saveClip.
		currentTransformation _ saveTransform.
	].
	^ retval
