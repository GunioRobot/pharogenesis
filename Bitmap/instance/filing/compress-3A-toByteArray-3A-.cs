compress: bm toByteArray: ba
	"Store a run-coded compression of the receiver into the byteArray ba,
	and return the last index stored into. ba is assumed to be large enough.
	The encoding is as follows...
		S {N D}*.
		S is the size of the original bitmap, followed by run-coded pairs.
		N is a run-length * 4 + data code.
		D, the data, depends on the data code...
			0	skip N words, D is absent
			1	N words with all 4 bytes = D (1 byte)
			2	N words all = D (4 bytes)
			3	N words follow in D (4N bytes)
		S and N are encoded as follows...
			0-223	0-223
			224-254	(0-30)*256 + next byte (0-7935)
			255		next 4 bytes"		
	| size k word j lowByte eqBytes i |
	<primitive: 237>
	self var: #bm declareC: 'int *bm'.
	self var: #ba declareC: 'unsigned char *ba'.
	size _ bm size.
	i _ self encodeInt: size in: ba at: 1.
	k _ 1.
	[k <= size] whileTrue:
		[word _ bm at: k.
		lowByte _ word bitAnd: 16rFF.
		eqBytes _ ((word >> 8) bitAnd: 16rFF) = lowByte
				and: [((word >> 16) bitAnd: 16rFF) = lowByte
				and: [((word >> 24) bitAnd: 16rFF) = lowByte]].
		j _ k.
		[j < size and: [word = (bm at: j+1)]]  "scan for = words..."
			whileTrue: [j _ j+1].
		j > k ifTrue:
			["We have two or more = words, ending at j"
			eqBytes
				ifTrue: ["Actually words of = bytes"
						i _ self encodeInt: j-k+1*4+1 in: ba at: i.
						ba at: i put: lowByte.  i _ i+1]
				ifFalse: [i _ self encodeInt: j-k+1*4+2 in: ba at: i.
						i _ self encodeBytesOf: word in: ba at: i].
			k _ j+1]
			ifFalse:
			["Check for word of 4 = bytes"
			eqBytes ifTrue:
				["Note 1 word of 4 = bytes"
				i _ self encodeInt: 1*4+1 in: ba at: i.
				ba at: i put: lowByte.  i _ i+1.
				k _ k + 1]
				ifFalse:
				["Finally, check for junk"
				[j < size and: [(bm at: j) ~= (bm at: j+1)]]  "scan for ~= words..."
					whileTrue: [j _ j+1].
				j = size ifTrue: [j _ j + 1].
				"We have one or more unmatching words, ending at j-1"
				i _ self encodeInt: j-k*4+3 in: ba at: i.
				k to: j-1 do:
					[:m | i _ self encodeBytesOf: (bm at: m) in: ba at: i].
				k _ j]]].
	^ i - 1  "number of bytes actually stored"
"
Space check:
 | n rawBytes myBytes b |
n _ rawBytes _ myBytes _ 0.
Form allInstancesDo:
	[:f | f unhibernate.
	b _ f bits.
	n _ n + 1.
	rawBytes _ rawBytes + (b size*4).
	myBytes _ myBytes + (b compressToByteArray size).
	f hibernate].
Array with: n with: rawBytes with: myBytes
ColorForms: (116 230324 160318 )
Forms: (113 1887808 1325055 )

Integerity check:
Form allInstances do:
	[:f | f unhibernate.
	f bits = (Bitmap decompressFromByteArray: f bits compressToByteArray)
		ifFalse: [self halt].
	f hibernate]

Speed test:
MessageTally spyOn: [Form allInstances do:
	[:f | Bitmap decompressFromByteArray: f bits compressToByteArray]]
"