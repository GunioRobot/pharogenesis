rebuildSpamDatabase
	| progressMorph estimatedSize spamFilter messageIds spamIds msg |
	Preferences celesteDespam ifFalse: [
		(self confirm: 'The spam filter is currently off. Would you like to turn it on?') ifTrue: [Preferences enable: #celesteDespam] ifFalse: [^self].
	].
	messageIds _ self allMessagesSorted last: (5000 min: self allMessages size).
	spamIds _ self messagesIn: '.spam.'.
	estimatedSize _ messageIds size.

	progressMorph _ ProgressMorph new.
	progressMorph label: 'Rebuilding spam database'.
	progressMorph openInWorld.

	spamFilter _ self spamFilter.
	spamFilter reset.
	messageIds do: [:msgId |
		msg _ self getMessage: msgId.
		(spamIds includes: msgId)
			ifTrue: [spamFilter classifyAsSpam: msg]
			ifFalse: [spamFilter classifyAsNotSpam: msg].
		progressMorph incrDone: 1 / estimatedSize.
	].
	
	progressMorph delete.
