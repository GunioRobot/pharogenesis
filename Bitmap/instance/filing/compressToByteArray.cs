compressToByteArray
	"Return a simple run-coded compression of the receiver into a byteArray:
		First 4 bytes are the size of the original Bitmap.
		This is followed by a number of runs...
		[0 means end of runs]
		[n = 1..127] [(n+3) copies of next byte]
		[n = 128..191] [(n-127) next bytes as is]
		[n = 192..255] [(n-190) copies of next 4 bytes]"

	^ ByteArray streamContents:
		[:s | 1 to: 4 do: [:i | s nextPut: (self size digitAt: 5-i)].	"positive size"
		self compressToStream: s]
"
Space check:
 | n rawBytes myBytes b |
n _ rawBytes _ myBytes _ 0.
Form allInstancesDo:
	[:f | b _ f bits.
	b size > 10 ifTrue:
		[n _ n + 1.
		rawBytes _ rawBytes + (b size*4).
		myBytes _ myBytes + (b compressToByteArray size)]].
Array with: n with: rawBytes with: myBytes
 (69 304604 87588 )

Speed test:
 | b |
Smalltalk garbageCollect.
MessageTally spyOn: [Form allInstances do:
	[:f | b _ f bits.
	b size > 10 ifTrue:
		[Bitmap decompressFromByteArray: b compressToByteArray]]]
"