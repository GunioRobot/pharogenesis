allUnSentMessagesIn: selectorSet 
	"Answer the subset of selectorSet which are not sent anywhere in the 
	system. "
	self deprecated: 'Use ''allUnsentMessagesIn:'' instead.'. 
	^ self allUnsentMessagesIn: selectorSet