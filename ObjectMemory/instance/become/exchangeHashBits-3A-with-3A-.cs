exchangeHashBits: oop1 with: oop2

	| hdr1 hdr2 |
	hdr1 _ self longAt: oop1.
	hdr2 _ self longAt: oop2.
	self longAt: oop1 put:
		((hdr1 bitAnd: AllButHashBits) bitOr: (hdr2 bitAnd: HashBits)).
	self longAt: oop2 put:
		((hdr2 bitAnd: AllButHashBits) bitOr: (hdr1 bitAnd: HashBits)).
