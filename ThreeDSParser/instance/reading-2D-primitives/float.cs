float
	"Generic Subchunk containing a float"
	| fltArray |
	fltArray _ FloatArray new: 1.
	fltArray basicAt: 1 put: self uLong.
	^fltArray at: 1.