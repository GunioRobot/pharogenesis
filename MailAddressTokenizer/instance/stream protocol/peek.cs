peek
	cachedToken ifNil: [ cachedToken := self nextToken. ].
	
	^cachedToken	