classHeader: oop put: newClass
	"Note:	This method should be in ObjectMemory"

	^ self longAt: oop - 4 put: newClass