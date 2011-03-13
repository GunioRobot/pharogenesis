atWrap: anInteger 
	"Answer my element at index anInteger. at: is used by a knowledgeable client to access an existing element.   If index is out of bounds, let it wrap around from the end to the beginning until it is in bounds.  6/18/96 tk"

^ self at: (anInteger - 1 \\ self size + 1)
