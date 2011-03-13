dialect: dialectSymbol contents: blockWithArg 
	| stream |
	stream _ self on: (Text new: 400).
	stream setDialect: dialectSymbol.
	blockWithArg value: stream.
	^ stream contents