filteredMessagesIn: categoryName

	| msgList |
	msgList _ mailDB messagesIn: categoryName.

	(customFilterBlock notNil) ifTrue:
		[msgList _ msgList select:
			[: id | customFilterBlock value: (mailDB getTOCentry: id) ]].
	(fromFilter size > 0) ifTrue:
		[msgList _ msgList select:
			[: id | (mailDB getTOCentry: id) from includesSubstring: fromFilter caseSensitive: false]].
	(subjectFilter size > 0) ifTrue:
		[msgList _ msgList select:
			[: id | (mailDB getTOCentry: id) subject includesSubstring: subjectFilter caseSensitive: false]].
	^msgList