endianness
	^endianness isNil 
		ifTrue: [endianness _ SmalltalkImage current endianness] 
		ifFalse: [endianness]