restoreHeadersAfterBecoming: list1 with: list2
	"Restore the headers of all oops in both lists. Exchange their hash bits so becoming objects in identity sets and dictionaries doesn't change their hash value."

	| fieldOffset oop1 oop2 hdr1 hdr2 |
	fieldOffset _ self lastPointerOf: list1.
	[fieldOffset >= BaseHeaderSize] whileTrue: [
		oop1 _ self longAt: list1 + fieldOffset.
		oop2 _ self longAt: list2 + fieldOffset.
		self restoreHeaderOf: oop1.
		self restoreHeaderOf: oop2.
		"Exchange has bits of the two objects."
		hdr1 _ self longAt: oop1.
		hdr2 _ self longAt: oop2.
		self longAt: oop1 put:
			((hdr1 bitAnd: AllButHashBits) bitOr: (hdr2 bitAnd: HashBits)).
		self longAt: oop2 put:
			((hdr2 bitAnd: AllButHashBits) bitOr: (hdr1 bitAnd: HashBits)).
		fieldOffset _ fieldOffset - 4.
	].