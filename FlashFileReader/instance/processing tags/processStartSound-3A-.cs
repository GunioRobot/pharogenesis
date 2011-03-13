processStartSound: data
	| id info |
	id := data nextWord.
	info := self processSoundInfoFrom: data.
	self recordStartSound: id info: info.
	^true