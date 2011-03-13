browseSenders
	"Create and schedule a message set browser on all methods in which the 
	currently selected message selector is sent. Do nothing if no message is 
	selected."

	messageListIndex ~= 0 
		ifTrue: [Smalltalk browseAllCallsOn: self selectedMessageName]