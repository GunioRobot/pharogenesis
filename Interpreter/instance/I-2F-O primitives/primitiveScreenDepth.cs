primitiveScreenDepth
	"Return a SmallInteger indicating the current depth of the OS screen. Negative values are used to imply LSB type pixel format an there is some support in the VM for handling either MSB or LSB"
	| depth |
	self export: true.
	depth _ self ioScreenDepth.
	self failed ifTrue:[^self primitiveFail].
	self pop: 1.
	self pushInteger: depth.