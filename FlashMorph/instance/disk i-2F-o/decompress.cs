decompress
	"Decompress the receiver"
	submorphs do:[:m| m decompress].
	self fullBounds. "Force computation"