linkMethod: classAndMethod
	"Make a linked message list and put this method in it.  For example, click here: LinkedMessageSet linkMethod:."

	"Do some checks here on the user's text!!!"
	self okToChange ifFalse: [^ self].
	messageList add: classAndMethod.
	self changed: #messageListChanged.
	self messageListIndex: messageList size.