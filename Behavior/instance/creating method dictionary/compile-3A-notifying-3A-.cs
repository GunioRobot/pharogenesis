compile: code notifying: requestor 
	"Compile the argument, code, as source code in the context of the 
	receiver and insEtall the result in the receiver's method dictionary. The 
	second argument, requestor, is to be notified if an error occurs. The 
	argument code is either a string or an object that converts to a string or 
	a PositionableStream. This method also saves the source code."
	| method selector methodNode |
	method _ self
		compile: code "a Text"
		notifying: requestor
		trailer: #(0 0 0 0)
		ifFail: [^nil]
		elseSetSelectorAndNode: 
			[:sel :parseNode | selector _ sel.  methodNode _ parseNode].
	method putSource: code "a Text" fromParseNode: methodNode inFile: 2
			withPreamble: [:f | f cr; nextPut: $!; nextChunkPut: 'Behavior method'; cr].
	^selector