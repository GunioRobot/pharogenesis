atAll: indexArray putAll: valueArray
	"Store the elements of valueArray into the slots
	of this collection selected by indexArray."
	indexArray with: valueArray do:
		[:i :x | self at: i put: x]