emitLong: mode on: aStream 
	"Emit extended variable access."
	| type index |
	code < 256
		ifTrue:
			[code < 16
			ifTrue: [type _ 0.
					index _ code]
			ifFalse: [code < 32
					ifTrue: [type _ 1.
							index _ code - 16]
					ifFalse: [code < 96
							ifTrue: [type _ code // 32 + 1.
									index _ code \\ 32]
							ifFalse: [self error: 
									'Sends should be handled in SelectorNode']]]]
		ifFalse: 
			[index _ code \\ 256.
			type _ code // 256 - 1].
	index <= 63 ifTrue:
		[aStream nextPut: mode.
		^ aStream nextPut: type * 64 + index].
	"Compile for Double-exetended Do-anything instruction..."
	mode = LoadLong ifTrue:
		[aStream nextPut: DblExtDoAll.
		aStream nextPut: (#(64 0 96 128) at: type+1).  "Cant be temp (type=1)"
		^ aStream nextPut: index].
	mode = Store ifTrue:
		[aStream nextPut: DblExtDoAll.
		aStream nextPut: (#(160 0 0 224) at: type+1).  "Cant be temp or const (type=1 or 2)"
		^ aStream nextPut: index].
	mode = StorePop ifTrue:
		[aStream nextPut: DblExtDoAll.
		aStream nextPut: (#(192 0 0 0) at: type+1).  "Can only be inst"
		^ aStream nextPut: index].
