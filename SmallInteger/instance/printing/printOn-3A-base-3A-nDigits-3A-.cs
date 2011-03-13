printOn: aStream base: b nDigits: n 
	"Append a representation of this number in base b on aStream using nDigits.
	self must be positive."

	"allocating a String seems faster than streaming for SmallInteger"
	aStream nextPutAll: (self printStringBase: b nDigits: n)