allMatchingIDsAmong: messageIDs in: mailDB
	^messageIDs select: [ :id |
		| messageSummary |
		messageSummary := mailDB getTOCentry: id.
		messageSummary subjectHas: subjectPattern ]