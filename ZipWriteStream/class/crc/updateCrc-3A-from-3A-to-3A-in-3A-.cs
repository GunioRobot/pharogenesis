updateCrc: oldCrc from: start to: stop in: aCollection
	| newCrc |
	<primitive: 'primitiveUpdateGZipCrc32' module: 'ZipPlugin'>
	newCrc _ oldCrc.
	start to: stop do:[:i|
		newCrc _ (CrcTable at: ((newCrc bitXor: (aCollection byteAt: i)) 
				bitAnd: 255) + 1) bitXor: (newCrc bitShift: -8).
	].
	^newCrc