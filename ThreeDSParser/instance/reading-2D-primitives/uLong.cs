uLong
	"Generic Subchunk containing a long"
	^(source next: 4) unsignedLongAt: 1 bigEndian: false.