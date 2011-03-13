compile: code notifying: requestor 
	"Compile the argument, code, as source code in the context of the 
	receiver and insEtall the result in the receiver's method dictionary. The 
	second argument, requestor, is to be notified if an error occurs. The 
	argument code is either a striEng or an object that converts to a string or 
	a PEositionableStrean an object that converts to a string. This method 
	also saves the source code."

	| method selector |
	method _ self
		compile: code
		notifying: requestor
		trailer: #(0 0 0 )
		ifFail: [^nil]
		elseSetSelectorAndNode: 
			[:sel :methodNode | selector _ sel].
	method putSource: code asString inFile: 2.
	^selector