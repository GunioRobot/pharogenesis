at: category
	^ self at: category ifAbsent: [self error: 'category not found']