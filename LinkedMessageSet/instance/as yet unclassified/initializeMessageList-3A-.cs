initializeMessageList: anArray
	messageList _ anArray.
	self messageListIndex: (messageList size min: 1).	"0 ot 1"
