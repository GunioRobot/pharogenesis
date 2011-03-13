colorTable
	"Answer the table to use to determine colors"

	^ colorTable ifNil: [colorTable _ ST80ColorTable]