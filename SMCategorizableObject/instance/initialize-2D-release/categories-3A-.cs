categories: anArray
	"Method used when recreating the object in the image when we need
	to bind the category ids with the actual category objects."

	anArray do: [:i | self addCategory: (map categoryWithId: i)]