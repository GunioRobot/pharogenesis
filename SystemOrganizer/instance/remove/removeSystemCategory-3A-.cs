removeSystemCategory: category
	"remove all the classes associated with the category"

	(self superclassOrder: category) reverseDo: [:class | class removeFromSystem].
	self removeEmptyCategories