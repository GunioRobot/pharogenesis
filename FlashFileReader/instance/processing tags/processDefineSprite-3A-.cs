processDefineSprite: data
	| id frameCount |
	id _ data nextWord.
	self flag: #wrongSpec.
	frameCount _ data nextWord.
	self recordBeginSprite: id frames: frameCount.
	[self processTagFrom: data] whileTrue.
	self recordEndSprite: id.
	^true