writePLTEChunkOn: aStream
	"Write the PLTE chunk"
	| r g b colors |
	aStream nextPutAll: 'PLTE' asByteArray.
	(form isColorForm) 
		ifTrue:[colors := form colors]
		ifFalse:[colors := Color indexedColors copyFrom: 1 to: (1 bitShift: form depth)].
	colors do:[:aColor|
		r := (aColor red * 255) truncated.
		g := (aColor green * 255) truncated.
		b := (aColor blue * 255) truncated.
		aStream nextPut: r; nextPut: g; nextPut: b.
	].