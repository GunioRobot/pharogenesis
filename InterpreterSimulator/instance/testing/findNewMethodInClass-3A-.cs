findNewMethodInClass: class
"
	| cName |
	traceOn ifTrue:
		[cName _ (self sizeBitsOf: class) = 16r20
			ifTrue: ['class ' , (self nameOfClass: (self fetchPointer: 6 ofObject: class))]
			ifFalse: [(self nameOfClass: class)].
		self cr; print: cName , '>>' , (self stringOf: messageSelector)].
"
"
(self stringOf: messageSelector) = 'raisedToInteger:' ifTrue: [self halt].
"
	sendCount _ sendCount + 1.
(false "sendCount > 1090" "and: [sendCount\\10 = 0]") ifTrue:
		[Transcript print: sendCount; space.
		self validate].
	super findNewMethodInClass: class.