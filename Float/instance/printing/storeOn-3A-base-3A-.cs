storeOn: aStream base: base
	"Defined here to handle special cases of NaN Infinity and negative zero"
	
	| abs |
	self isNaN ifTrue: [aStream nextPutAll: 'NaN'. ^ self]. "check for NaN before sign"
	abs := self sign = -1 "Test sign rather than > 0 for special case of negative zero"
		ifTrue:
			[aStream nextPutAll: '-'.
			self negated]
		 ifFalse: [self].
	abs isInfinite ifTrue: [aStream nextPutAll: 'Infinity'. ^ self].
	base = 10 ifFalse: [aStream print: base; nextPut: $r].
	self = 0.0
		ifTrue: [aStream nextPutAll: '0.0'. ^ self]
		ifFalse: [abs absPrintOn: aStream base: base]