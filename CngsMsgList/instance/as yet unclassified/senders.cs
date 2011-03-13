senders
	"Create and schedule a message set browser on the methods in which the 
	selected message is sent."

	controller controlTerminate.
	listIndex ~= 0 
		ifTrue: [Smalltalk browseAllCallsOn: self selection asSymbol].
	controller controlInitialize