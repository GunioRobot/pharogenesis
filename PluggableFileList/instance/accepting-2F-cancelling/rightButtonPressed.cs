rightButtonPressed

	(canAcceptBlock value: directory value: fileName) ifFalse: [^nil].
	(validateBlock value: directory value: fileName value: newFiles) ifFalse: [^nil].
	accepted _ true.
	self changed: #close