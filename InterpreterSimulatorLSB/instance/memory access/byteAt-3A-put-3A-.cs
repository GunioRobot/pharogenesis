byteAt: byteAddress put: byte
	| lowBits long longAddress |
	lowBits _ byteAddress bitAnd: 3.
	longAddress _ byteAddress - lowBits.
	long _ self longAt: longAddress.
	long _ (lowBits caseOf: {
		[0] -> [ (long bitAnd: 16rFFFFFF00) bitOr: byte ].
		[1] -> [ (long bitAnd: 16rFFFF00FF) bitOr: (byte bitShift: 8) ].
		[2] -> [ (long bitAnd: 16rFF00FFFF) bitOr: (byte bitShift: 16)  ].
		[3] -> [ (long bitAnd: 16r00FFFFFF) bitOr: (byte bitShift: 24)  ]
	}).

	self longAt: longAddress put: long.
