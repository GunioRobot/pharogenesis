atAll: indexArray
	"Return the selected elements in order"
	^ indexArray collect: [:i | self at: i]