messageListSelectorTitle
	| selector aString aStamp |
	Preferences timeStampsInMenuTitles
		ifFalse:
			[^ nil].
	(selector _ self selectedMessageName) ifNotNil:
		[aString _ selector truncateWithElipsisTo: 28.
		^ (aStamp _ self timeStamp) size > 0
			ifTrue:
				[aString, String cr, aStamp]
			ifFalse:
				[aString]].
	^ nil