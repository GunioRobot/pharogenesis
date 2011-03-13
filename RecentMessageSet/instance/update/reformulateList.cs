reformulateList
	"Reformulate the receiver's list.  Exclude methods now deleted"

	self initializeMessageList: (MessageSet extantMethodsIn: Utilities recentMethodSubmissions reversed).
	self messageListIndex: (messageList size min: 1).	"0 or 1"
	self changed: #messageList.
	self changed: #messageListIndex