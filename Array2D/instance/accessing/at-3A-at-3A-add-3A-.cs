at: x at: y add: value
	"Add value (using #+) to the existing element at index x,y."

	| index |
	index _ self indexX: x y: y.
	^ contents at: index put: (contents at: index) + value