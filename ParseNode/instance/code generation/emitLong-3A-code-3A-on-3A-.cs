emitLong: dist code: longCode on: aStream 
	"Force a two-byte jump."
	| code distance |
	code _ longCode.
	distance _ dist.
	distance < 0
		ifTrue: 
			[distance _ distance + 1024.
			code _ code - 4]
		ifFalse: 
			[distance > 1023 ifTrue: [distance _ -1]].
	distance < 0
		ifTrue: 
			[self error: 'A block compiles more than 1K bytes of code']
		ifFalse: 
			[aStream nextPut: distance // 256 + code.
			aStream nextPut: distance \\ 256]