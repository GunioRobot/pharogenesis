long
	"Generic Subchunk containing a long"
	^(source next: 4) longAt: 1 bigEndian: false.