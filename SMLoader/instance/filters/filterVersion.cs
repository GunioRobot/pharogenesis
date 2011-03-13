filterVersion
	"Ignore spaces in the version string, they're sometimes spurious.

	Not used anymore."

	^[:package | package categories anySatisfy:  
		[:cat | (cat name, '*') match: (Smalltalk version copyWithout: $ ) ]]