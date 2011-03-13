categories
	^ environment organization categories collect: [:cat | OBClassCategoryNode 
															on: cat
															inEnvironment: environment]