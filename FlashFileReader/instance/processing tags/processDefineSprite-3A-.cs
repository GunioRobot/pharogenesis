processDefineSprite: data
	| id frameCount |
	id := data nextWord.
	self flag: #wrongSpec.
	frameCount := data nextWord.
	self recordBeginSprite: id frames: frameCount.
	[self processTagFrom: data] whileTrue.
	self recordEndSprite: id.
	^true