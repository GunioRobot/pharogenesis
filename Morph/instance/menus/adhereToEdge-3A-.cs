adhereToEdge: edgeSymbol 
	(owner isNil or: [owner isHandMorph]) ifTrue: [^self].
	self perform: (edgeSymbol , ':') asSymbol
		withArguments: (Array with: (owner perform: edgeSymbol))