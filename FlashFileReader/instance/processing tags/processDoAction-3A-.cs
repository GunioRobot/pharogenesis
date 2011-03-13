processDoAction: data
	| actions |
	actions := self processActionRecordsFrom: data.
	self recordFrameActions: actions.
	^true