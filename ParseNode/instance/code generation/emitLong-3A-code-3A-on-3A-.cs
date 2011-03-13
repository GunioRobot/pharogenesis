emitLong: dist code: longCode on: aStream 
	"Force a two-byte jump."
	| code distance |
	code := longCode.
	distance := dist.
	distance < 0
		ifTrue: 
			[distance := distance + 1024.
			code := code - 4]
		ifFalse: 
			[distance > 1023 ifTrue: [distance := -1]].
	distance < 0
		ifTrue: 
			[self error: 'A block compiles more than 1K bytes of code']
		ifFalse: 
			[aStream nextPut: distance // 256 + code.
			aStream nextPut: distance \\ 256]