reformulateList
	| myList |
	"Reformulate the receiver's list.  Exclude methods now deleted"

	myList _ Utilities recentMethodSubmissions reversed select: [ :each | each isValid].
	self initializeMessageList: myList.
	self messageListIndex: (messageList size min: 1).	"0 or 1"
	self changed: #messageList.
	self changed: #messageListIndex