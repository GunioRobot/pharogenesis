hash
	"Make sure that equal (=) ByteArrays hash equally."

	self size = 0 ifTrue: [^ 2001].
	^ ((self at: 1) bitShift: 8) + (self at: self size)
