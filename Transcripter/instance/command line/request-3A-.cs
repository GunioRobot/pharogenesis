request: prompt
	| startPos char contents | 
	self cr; show: prompt.
	startPos _ position.
	[[Sensor keyboardPressed] whileFalse.
	(char _ Sensor keyboard) = Character cr]
		whileFalse:
		[char = Character backspace
			ifTrue: [readLimit _ position _ (position - 1 max: startPos)]
			ifFalse: [self nextPut: char].
		self endEntry].
	contents _ self contents.
	^ contents copyFrom: startPos + 1 to: contents size