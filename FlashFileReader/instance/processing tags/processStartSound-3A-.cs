processStartSound: data
	| id info |
	id _ data nextWord.
	info _ self processSoundInfoFrom: data.
	self recordStartSound: id info: info.
	^true