isNewMessageSpam: msg
	^ self isNewMessage: msg inCategory: 'spam' withProbability: 0.9