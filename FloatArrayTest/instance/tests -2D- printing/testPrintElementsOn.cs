testPrintElementsOn

	| aStream result allElementsAsString |
	result:=''.
	aStream:= ReadWriteStream on: result.
	
	self nonEmpty printElementsOn: aStream .
	allElementsAsString:=(result findBetweenSubStrs: ' ' ).
	1 to: allElementsAsString size do:
		[:i | 
		self assert: (allElementsAsString at:i)=((self nonEmpty at:i)asString).
			].