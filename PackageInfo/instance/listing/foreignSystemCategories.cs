foreignSystemCategories
	^ SystemOrganization categories
		reject: [:cat | self includesSystemCategory: cat] 