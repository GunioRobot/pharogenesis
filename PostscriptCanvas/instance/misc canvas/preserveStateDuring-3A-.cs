preserveStateDuring: aBlock
	| retval saveClip saveTransform |
	target preserveStateDuring: [ :innerTarget |
		saveClip _ clipRect.
		saveTransform _ currentTransformation.
		gstateStack addLast: currentFont.
		gstateStack addLast: currentColor.
		retval _ aBlock value: self.
		currentColor _ gstateStack removeLast.
		currentFont _ gstateStack removeLast.
		clipRect _ saveClip.
		currentTransformation _ saveTransform.
	].
	^ retval
