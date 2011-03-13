attributes
	| val |
	^ flags 
		ifNil: [ super attributes ]
		ifNotNil: 
			[ (val := ByteArray new: 4) 
				longAt: 1
				put: flags
				bigEndian: false.
			val ]