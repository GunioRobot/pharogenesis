browseUnsentMessagesInClass: aClass
	"SystemNavigation default browseUnsentMessagesWithProgressBarInClass: BlockContext"
	| unsentMessages |
	unsentMessages := self unsentMessagesWithProgressBarInClass: aClass.
	^self 
		browseMessageList: unsentMessages asSortedCollection
		name: 'Unsent messages in class ', aClass name 
 