centerColor: aColor
	"Set the center color as indicated; map nil into transparent"

	cColor _ aColor ifNil: [Color transparent]