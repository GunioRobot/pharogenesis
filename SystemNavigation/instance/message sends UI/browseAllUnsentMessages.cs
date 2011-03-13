browseAllUnsentMessages
	"SystemNavigation default browseUnsentMessages"
	| unsentMessages |
	unsentMessages := self allUnsentMessagesWithProgressBar.
	^self 
		browseMessageList: unsentMessages asSortedCollection
		name: 'All unsent messages' 
 