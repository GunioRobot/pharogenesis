allMatchingIDsAmong: messageIDs in: mailDB
	^messageIDs select: [ :id |
		(mailDB getTOCentry: id) participantHas: participantSubstring ]