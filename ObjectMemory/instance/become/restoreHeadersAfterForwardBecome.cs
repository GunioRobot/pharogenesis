restoreHeadersAfterForwardBecome
	"Forward become leaves us with no original oops in the mutated object list,
	so we must enumerate the (four-word) forwarding blocks
	where we have stored backpointers."

	| oop1 fwdBlock oop2 hdr1 hdr2 |
	"This loop start is copied from fwdBlockGet:"
	fwdBlock _ (endOfMemory + BaseHeaderSize + 7) bitAnd: 16rFFFFFFF8.
	fwdBlock _ fwdBlock + 16.  "fwdBlockGet: did a pre-increment"
	[fwdBlock <= fwdTableNext]  "fwdTableNext points to the last active block"
		whileTrue:
		[oop1 _ self longAt: fwdBlock + 8.  "Backpointer to mutated object."
		oop2 _ self longAt: fwdBlock.
		self restoreHeaderOf: oop1.
		"Change the hash of the new oop (oop2) to be that of the old (oop1)
		so mutated objects in hash structures will be happy after the change."
		hdr1 _ self longAt: oop1.
		hdr2 _ self longAt: oop2.
		self longAt: oop2 put:
			((hdr2 bitAnd: AllButHashBits) bitOr: (hdr1 bitAnd: HashBits)).
		fwdBlock _ fwdBlock + 16].