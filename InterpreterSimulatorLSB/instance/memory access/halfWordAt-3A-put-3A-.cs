halfWordAt: byteAddress put: a16BitValue
    "Return the half-word at byteAddress which must be even."
	| lowBits long longAddress |
	lowBits _ byteAddress bitAnd: 2.
	lowBits = 0
		ifTrue: [ "storing into LS word"
			long _ self longAt: byteAddress.
			self longAt: byteAddress put: ((long bitAnd: 16rFFFF0000) bitOr: a16BitValue)
		]
		ifFalse: [
			longAddress _ byteAddress - 2.
			long _ self longAt: longAddress.
			self longAt: longAddress
				put: ((long bitAnd: 16rFFFF) bitOr: (a16BitValue bitShift: 16))
		]