browseMessageSet: messageList name: title autoSelect: autoSelectString
	"Open a message set browser"
	^MessageSet
		openMessageList: messageList 
		name: title 
		autoSelect: autoSelectString