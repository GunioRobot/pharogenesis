printOn: aStream
	| first |
	aStream nextPutAll: '#('; print: phoneme; space; print: loudness; space; print: duration.
	self pitchPoints isNil ifTrue: [aStream nextPut: $). ^ self].
	aStream nextPutAll: ' #('.
	first _ true.
	self pitchPoints do: [ :each |
		first ifFalse: [aStream space].
		aStream print: each x; space; print: each y.
		first _ false].
	aStream nextPutAll: '))'