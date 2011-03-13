checkForUnsentMessages
	"Check the change set for unsent messages, and if any are found, open up a message-list browser on them"

	| nameLine allChangedSelectors augList unsent messageList |
	nameLine _ '"', self name, '"'.
	allChangedSelectors _ Set new.
	(augList _ self changedMessageListAugmented) do:
		[:aChange |
			MessageSet parse: aChange toClassAndSelector: [:cls :sel | (cls notNil and:
				[cls includesSelector: sel]) ifTrue: [allChangedSelectors add: sel]]].

	unsent _ Smalltalk allUnSentMessagesIn: allChangedSelectors.
	unsent size = 0
		ifTrue:
			[self inform: 'There are no unsent 
messages in change set
', nameLine]
		ifFalse:
			[messageList _ augList select:
				[:aChange |
					MessageSet parse: aChange toClassAndSelector:
						[:cls :sel | unsent includes: sel]].

			Smalltalk browseMessageList: messageList name: 'Unsent messages in ', nameLine]
