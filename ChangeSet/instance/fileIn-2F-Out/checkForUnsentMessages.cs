checkForUnsentMessages
	"Check the change set for unsent messages, and if any are found, open 
	up a message-list browser on them"
	| nameLine allChangedSelectors augList unsent |
	nameLine _ '"' , self name , '"'.
	allChangedSelectors _ Set new.
	(augList _ self changedMessageListAugmented)
		do: [:each | each isValid
				ifTrue: [allChangedSelectors add: each methodSymbol]].
	unsent _ self systemNavigation allUnSentMessagesIn: allChangedSelectors.
	unsent size = 0
		ifTrue: [^ self inform: 'There are no unsent 
messages in change set
' , nameLine].
	self systemNavigation
		browseMessageList: (augList
				select: [:each | unsent includes: each methodSymbol])
		name: 'Unsent messages in ' , nameLine