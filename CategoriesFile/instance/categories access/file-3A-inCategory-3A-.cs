file: messageID inCategory: categoryName 
	"Add the given message ID to the given category. The target category  
	must be a real category, not a pseudo-category."
	categoryName = '.unclassified.' | categoryName = '.all.' ifTrue: [^ self].
	(categories includesKey: categoryName)
		ifFalse: [categories at: categoryName put: PluggableSet integerSet].
	(categories at: categoryName)
		add: messageID