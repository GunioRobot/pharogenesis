allUnsentMessages
	"Answer an array of all the messages defined by the receiver that are not sent anywhere in the system.  5/8/96 sw"

	^ Smalltalk allUnSentMessagesIn: self selectors