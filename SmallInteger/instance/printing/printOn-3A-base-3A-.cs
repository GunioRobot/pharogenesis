printOn: aStream base: b 
	"Append a representation of this number in base b on aStream."

	self < 0
		ifTrue: [aStream nextPut: $-.
			aStream nextPutAll: (self negated printStringBase: b).
			^self].

	"allocating a String seems faster than streaming for SmallInteger"
	aStream nextPutAll: (self printStringBase: b)