methodPrintOn: aStream
	aStream nextPut: $(; print: self selector; tab.
	self selector size < 4 ifTrue: [aStream tab].
	self selector size < 8 ifTrue: [aStream tab].
	aStream print: self steady; tab; tab; print: self fixed; tab; tab; print: self proportion; tab; tab; print: self external; tab; tab; print: self internal; nextPut: $)