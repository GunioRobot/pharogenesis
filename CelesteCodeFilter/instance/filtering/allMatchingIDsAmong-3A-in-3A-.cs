allMatchingIDsAmong: messageIDs in: mailDB
	^messageIDs select: [ :id |
		| messageSummary |
		messageSummary := mailDB getTOCentry: id.
		tester value: messageSummary ]