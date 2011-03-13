makeMyPage

	currentPage ifNotNil:
		[(currentPage isMemberOf: ImageMorph)
			ifTrue: ["currentPage is already an ImageMorph."
					(currentPage image extent = frameSize
						and: [currentPage image depth = frameDepth])
						ifTrue: [^ self  "page is already properly dimensioned."].
					^ currentPage image: (Form extent: frameSize depth: frameDepth)]
			ifFalse: [currentPage releaseCachedState; delete]].
	currentPage _ ImageMorph new image: (Form extent: frameSize depth: frameDepth).
	currentPage lock.
	pages _ OrderedCollection with: currentPage.
	self addMorphFront: currentPage