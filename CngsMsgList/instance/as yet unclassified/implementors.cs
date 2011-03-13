implementors
	"Create and schedule a message set browser on the implementations of the 
	selected message."

	controller controlTerminate.
	listIndex ~= 0 
		ifTrue: [Smalltalk browseAllImplementorsOf: self selection asSymbol].
	controller controlInitialize