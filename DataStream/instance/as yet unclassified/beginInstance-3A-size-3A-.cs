beginInstance: aClass size: anInteger
	"This is for use by storeDataOn: methods.
	 Cf. Object>>storeDataOn:."

		"Addition of 1 seems to make extra work, since readInstance
		has to compensate.  Here for historical reasons dating back
		to Kent Beck's original implementation in late 1988.

		Also, we could save 5 bytes per instance by putting a Str255
		on byteStream instead of putting a Symbol on self (which
		entails a 1-byte type tag and a 4-byte length count).

		Also, we could be more robust by emitting info indicating
		whether aClass is fixed or variable, pointer or bytes, and
		how many instance vars it has."

	byteStream nextNumber: 4 put: anInteger + 1.

	self nextPut: aClass name