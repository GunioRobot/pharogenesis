at: x at: y put: value
	"Store value at index x,y and answer it."

	^ contents at: (self indexX: x y: y) put: value