atWrap: index put: value
	"Store into this element of an indexable object.  If index is out of bounds, let it wrap around from the end to the beginning until it is in bounds.  6/18/96 tk"

^ self at: (index - 1 \\ self size + 1) put: value
