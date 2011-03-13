primitiveDisablePowerManager
	"Pass in a non-negative value to disable the architectures powermanager if any, zero to enable"

	| integer |
	self export: true.
	integer _ self stackIntegerValue: 0.
	successFlag ifTrue: [
		self ioDisablePowerManager: integer.
		self pop: 1].  "integer; leave rcvr on stack"
