removeFromAllCategories: x
	self realCategories do: [:categoryName | self remove: x fromCategory: categoryName].