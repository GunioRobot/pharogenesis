removeSystemCategory: category
	"remove all the classes associated with the category"

	(self superclassOrder: category) do: [:class | class removeFromSystem].
	self removeEmptyCategories