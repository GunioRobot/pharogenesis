scanCharacters
	self inline: true.
	scanDisplayFlag ifTrue: [
		self clipRange.
		(combinationRule = 30) | (combinationRule = 31) ifTrue:
			[^ interpreterProxy primitiveFail].
		self lockSurfaces ifFalse: [^ interpreterProxy primitiveFail]].
	self scanCharactersLockedAndClipped.
	scanDisplayFlag ifTrue:[self unlockSurfaces].