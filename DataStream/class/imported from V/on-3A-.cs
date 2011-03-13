on: aStream
    "Open a new DataStream onto a low-level I/O stream.
     11/19/92 jhm: Use new, not basicNew."

	| aClass |
	(aClass _ Smalltalk hyperSqueakSupportClass) == nil
		ifFalse:
			[aClass initSysLib].	"Get current sys globals"
	aStream binary.
    ^ self basicNew setStream: aStream