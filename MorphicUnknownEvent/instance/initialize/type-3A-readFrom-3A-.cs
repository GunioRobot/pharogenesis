type: eventType readFrom: aStream
	| typeAndArg |
	timeStamp _ Integer readFrom: aStream.
	aStream skip: 1.
	typeAndArg _ Object readFrom: aStream.
	type _ typeAndArg first.
	argument _ typeAndArg last.