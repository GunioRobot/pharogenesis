processDefineButton2: data
	| id flags actions condition actionOffset |
	data hasAlpha: true.
	id := data nextWord.
	self recordDefineButton: id.
	flags := data nextByte.
	self recordButton: id trackAsMenu: flags = 0.
	self flag: #wrongSpec.
	actionOffset := data nextWord.
	self processButtonRecords: id from: data cxForm: true.
	[actionOffset = 0] whileFalse:[
		actionOffset := data nextWord.
		condition := data nextWord.
		actions := self processActionRecordsFrom: data.
		self recordButton: id actions: actions condition: condition].
	data hasAlpha: false.
	self recordEndButton: id.
	^true