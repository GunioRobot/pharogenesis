printOn: aStream
	aStream
		nextPut: $[; print: left; nextPut: $,; print: text; nextPut: $,; print: right; nextPut: $];
		nextPutAll: ' -> '.
	phonemes isEmpty ifTrue: [aStream nextPutAll: '{}'] ifFalse: [aStream nextPut: $/].
	phonemes do: [ :each | aStream nextPutAll: each name; nextPut: $/]