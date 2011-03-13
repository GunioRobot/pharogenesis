browseSenders
	"Show a menu of all messages that send the currently selected message.
	Create and schedule a message set browser of of the chosen message. Do
	nothing if no message is chosen."

	contextStackIndex ~= 0 
		ifTrue: [Smalltalk browseAllCallsOn: self selectedMessageName]