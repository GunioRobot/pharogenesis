ensureSuitableDefaults

	listOfPages ifNil: [
		listOfPages _ Project allMorphicProjects collect: [ :each | {each name}].
		threadName _ 'all (default)' translated.
		self class know: listOfPages as: threadName.
	].
	currentIndex ifNil: [currentIndex _ 0].
