intToNetAddress: addr
	"Convert the given 32-bit integer into an internet network address represented as a four-byte ByteArray."

	| netAddressOop |
	netAddressOop _
		self instantiateSmallClass: (self splObj: ClassByteArray)
			sizeInBytes: 8
			fill: 0.
	self storeByte: 0 ofObject: netAddressOop
		withValue: ((addr >> 24) bitAnd: 16rFF).
	self storeByte: 1 ofObject: netAddressOop
		withValue: ((addr >> 16) bitAnd: 16rFF).
	self storeByte: 2 ofObject: netAddressOop
		withValue: ((addr >> 8) bitAnd: 16rFF).
	self storeByte: 3 ofObject: netAddressOop
		withValue: (addr bitAnd: 16rFF).
	^ netAddressOop
