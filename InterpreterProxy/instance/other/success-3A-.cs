success: aBoolean
	successFlag not ifTrue:[^self].
	successFlag _ successFlag and:[aBoolean].
	successFlag not ifTrue:[
		(self confirm:'A primitive is failing -- Stop simulation?') ifTrue:[self halt]].