restoreHeadersAfterBecoming: list1 with: list2
	"Restore the headers of all oops in both lists. Exchange their hash bits so becoming objects in identity sets and dictionaries doesn't change their hash value."

	| fieldOffset oop1 oop2 |
	fieldOffset _ self lastPointerOf: list1.
	[fieldOffset >= BaseHeaderSize] whileTrue: [
		oop1 _ self longAt: list1 + fieldOffset.
		oop2 _ self longAt: list2 + fieldOffset.
		self restoreHeaderOf: oop1.
		self restoreHeaderOf: oop2.
		self exchangeHashBits: oop1 with: oop2.
		fieldOffset _ fieldOffset - 4.
	].