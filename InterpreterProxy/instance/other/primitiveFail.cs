primitiveFail
	(self confirm:'A primitive is failing -- Stop simulation?') ifTrue:[self halt].
	successFlag _ false.