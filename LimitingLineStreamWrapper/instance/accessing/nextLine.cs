nextLine

	| thisLine |
	self atEnd ifTrue: [^nil].
	thisLine _ line.
	line _ stream nextLine.
	^thisLine
