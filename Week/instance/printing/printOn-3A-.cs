printOn: aStream
	aStream nextPutAll:
		self month printString, ', ',
		(#('1st week' '2nd week' '3rd week' '4th week' '5th week' '6th week') at: self index)