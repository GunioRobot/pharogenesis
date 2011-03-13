storeCodeOn: aStream
	"Add in some smarts for division by zero."

	aStream nextPut: $(.
	(submorphs at: 1) storeCodeOn: aStream.
	aStream space.
	(submorphs at: 2) storeCodeOn: aStream.
	submorphs size > 2 ifTrue: [
		(self catchDivideByZero: aStream) ifFalse: [
			aStream space.
			(submorphs at: 3) storeCodeOn: aStream]].
	aStream nextPut: $).
