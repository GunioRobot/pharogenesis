processDefineButton2: data
	| id flags actions condition actionOffset |
	data hasAlpha: true.
	id _ data nextWord.
	self recordDefineButton: id.
	flags _ data nextByte.
	self recordButton: id trackAsMenu: flags = 0.
	self flag: #wrongSpec.
	actionOffset _ data nextWord.
	self processButtonRecords: id from: data cxForm: true.
	[actionOffset = 0] whileFalse:[
		actionOffset _ data nextWord.
		condition _ data nextWord.
		actions _ self processActionRecordsFrom: data.
		self recordButton: id actions: actions condition: condition].
	data hasAlpha: false.
	self recordEndButton: id.
	^true