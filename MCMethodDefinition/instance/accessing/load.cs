load
	self actualClass
		compile: source
		classified: category
		withStamp: timeStamp
		notifying: (SyntaxError new category: category)