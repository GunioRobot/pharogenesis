processDefineButton: data
	| id actions |
	id _ data nextWord.
	self recordDefineButton: id.
	self processButtonRecords: id from: data cxForm: false.
	actions _ self processActionRecordsFrom: data.
	self recordButton: id actions: actions.
	self recordEndButton: id.
	^true