peek
	cachedToken ifNil: [ cachedToken _ self nextToken. ].
	
	^cachedToken	