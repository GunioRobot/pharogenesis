overrideMethods
	^ self extensionMethods select: [:ea | self isOvverideMethod: ea]