bytes: aBytesOop Rshift: anInteger bytes: b lookfirst: a 
	"Attention: this method invalidates all oop's! Only newBytes is valid at return."
	"Shift right 8*b+anInteger bits, 0<=n<8.         
	Discard all digits beyond a, and all zeroes at or below a."
	"Does not normalize."
	| n x f m digit i oldLen newLen newBytes |
	n _ 0 - anInteger.
	x _ 0.
	f _ n + 8.
	i _ a.
	m _ 255 bitShift: 0 - f.
	digit _ self digitOfBytes: aBytesOop at: i.
	[((digit bitShift: n)
		bitOr: x)
		= 0 and: [i ~= 1]]
		whileTrue: 
			[x _ digit bitShift: f.
			"Can't exceed 8 bits"
			i _ i - 1.
			digit _ self digitOfBytes: aBytesOop at: i].
	i <= b ifTrue: [^ interpreterProxy instantiateClass: (interpreterProxy fetchClassOf: aBytesOop)
			indexableSize: 0"Integer new: 0 neg: self negative"].
	"All bits lost"
	oldLen _ self byteSizeOfBytes: aBytesOop.
	newLen _ i - b.
	self remapOop: aBytesOop in: [newBytes _ interpreterProxy instantiateClass: (interpreterProxy fetchClassOf: aBytesOop)
					indexableSize: newLen].
	"r _ Integer new: i - b neg: self negative."
	"	count _ i.       
	"
	self
		cCoreBytesRshiftCount: i
		n: n
		m: m
		f: f
		bytes: b
		from: (interpreterProxy firstIndexableField: aBytesOop)
		len: oldLen
		to: (interpreterProxy firstIndexableField: newBytes)
		len: newLen.
	^ newBytes