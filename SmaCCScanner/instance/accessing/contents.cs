contents
	| writeStream token |
	writeStream := WriteStream on: Array new.
	[self atEnd] whileFalse: 
			[token := self next.
			token notNil ifTrue: [writeStream nextPut: token]].
	^writeStream contents