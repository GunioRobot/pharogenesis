removeMessage
	"Remove the selected message from the system."

	messageListIndex = 0 ifTrue: [^ self].
	self okToChange ifFalse: [^ self].

	super removeMessage.
	"my #reformulateList method, called from the super #removeMethod method, will however try to preserve the selection, so we take pains to clobber it by the below..."
	messageListIndex _ 0.
	self changed: #messageList.
	self changed: #messageListIndex.
	contents _ nil.
	self contentsChanged