makeMyPage
	currentPage ifNotNil: [currentPage releaseCachedState; delete].
	currentPage _ ImageMorph new image: (Form extent: frameSize depth: frameDepth).
	pages _ OrderedCollection with: currentPage.
	self addMorphBack: currentPage.