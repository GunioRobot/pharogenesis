compressToStream: aBinaryStream
	"Return a simple run-coded compression of the receiver into a byteArray:
		(Caller has put negated size of original Bitmap in first 4 bytes.)
		Then put out a number of runs...
		[0 means end of runs]
		[n = 1..127] [(n+3) copies of next byte]
		[n = 128..191] [(n-127) next bytes as is]
		[n = 192..255] [(n-190) copies of next 4 bytes]"

	| here end runLen startAndLen junkLen s |
	s _ aBinaryStream.
	here _ 1.  end _ self size*4.
	[here <= end] whileTrue:
		["Scan for a run of 4..130 = bytes..."
		runLen _ self scanForRunOf: 4 from: here to: (here+129 min: end).
		runLen > 0
			ifTrue:
			[s nextPut: runLen - 3.  "Codes 1..127 mean n+3 copies of next byte"
			s nextPut: (self byteAt: here).
			here _ here + runLen]
			ifFalse:
			["Scan for a junk run (never 4 or more = bytes) of length 1..64
				[dont want to find runs of 3 as we would miss aaabaaab]"
			runLen _ self scanForNoRunOf: 4 from: here to: (here+63 min: end).
			"See if there is a 4-byte repeating pattern in the junk"
			startAndLen _ self scanForWordRunFrom: here to: (here+runLen-1 min: end).
			startAndLen first = 0
				ifTrue: [junkLen _  runLen]
				ifFalse: [junkLen _ startAndLen first - here].
			"Now output the junk up to repeating words if any..."
			junkLen > 0
				ifTrue: [s nextPut: junkLen+127.  "Codes 128..191 mean n-127 bytes of junk"
						0 to: junkLen-1 do: [:i | s nextPut: (self byteAt: here + i)].
						here _ here + junkLen].
			startAndLen first > 0
				ifTrue: ["Note: later may want to look for more copies of this
						4-byte pattern up to 65"
						s nextPut: startAndLen last+190.
							"Codes 192-255 mean n-190  copies of next 4 bytes"
						0 to: 3 do: [:i | s nextPut: (self byteAt: here + i)].
						here _ here + (startAndLen last * 4)]]].
	s nextPut: 0 "zero end-flag to simplify decompressor"
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