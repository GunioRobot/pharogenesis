reformulateList
	self initializeMessageList: Utilities recentMethodSubmissions reversed.
	self messageListIndex: (messageList size min: 1).	"0 or 1"
	self changed: #messageList.
	self changed: #messageListIndex