decompressAll
	"Profile the decompression speed"
	[self atEnd] whileFalse:[
		position _ readLimit.
		self next "Provokes decompression"
	].