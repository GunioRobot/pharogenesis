partNamesAndTypesForViewer
	"Return an array of part names and part types for use in a viewer on the receiver"

"		name		type		r/w			get selector			put selector
		-----------	---------		-----------	---------------------	-------------   "
	^ #(
		(name		string		readWrite	externalName		renameTo:)
		(x 			number		readWrite	x					x:)
		(y			number		readWrite	y					y:)
		(colorUnder	color		readOnly	colorUnder			unused))