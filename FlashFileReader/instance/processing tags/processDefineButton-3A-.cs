processDefineButton: data
	| id actions |
	id := data nextWord.
	self recordDefineButton: id.
	self processButtonRecords: id from: data cxForm: false.
	actions := self processActionRecordsFrom: data.
	self recordButton: id actions: actions.
	self recordEndButton: id.
	^true