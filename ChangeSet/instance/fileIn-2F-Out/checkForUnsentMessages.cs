checkForUnsentMessages
	| nameLine allChangedSelectors augList unsent messageList |
	nameLine _ '"', self name, '"'.
	allChangedSelectors _ Set new.
	(augList _ self changedMessageListAugmented) do:
		[:aChange |
			MessageSet parse: aChange toClassAndSelector: [:cls :sel | cls ifNotNil: [allChangedSelectors add: sel]]].

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
