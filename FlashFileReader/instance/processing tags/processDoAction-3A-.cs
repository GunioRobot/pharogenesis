processDoAction: data
	| actions |
	actions _ self processActionRecordsFrom: data.
	self recordFrameActions: actions.
	^true