messageListSelectorTitle
	| selector aString aStamp aSize |

	(selector _ self selectedMessageName)
		ifNil:
			[aSize _ self messageList size.
			^ (aSize == 0 ifTrue: ['no'] ifFalse: [aSize printString]), ' message', (aSize == 1 ifTrue: [''] ifFalse: ['s'])]
		ifNotNil:
			[Preferences timeStampsInMenuTitles
				ifFalse:	[^ nil].
			aString _ selector truncateWithElipsisTo: 28.
			^ (aStamp _ self timeStamp) size > 0
				ifTrue:
					[aString, String cr, aStamp]
				ifFalse:
					[aString]]