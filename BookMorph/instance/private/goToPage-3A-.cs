goToPage: pageNumber

	| pageIndex  oldOrigin aWorld oldRect oldPageNumber ascending |
	pages isEmpty ifTrue: [^ self].

	oldPageNumber _ pages indexOf: currentPage ifAbsent: [1].

	pageIndex _ pageNumber asInteger.

	"pageIndex _ (pageIndex max: 1) min: pages size."
	self flag: #deferred.  "The above rather than the below leads to the book pages of a tabbed palette complex being stacked upon one another.  Revisit this sucker!"

	pageNumber < 1 ifTrue: [pageIndex _ pages size].
	pageNumber > pages size ifTrue: [pageIndex _ 1].


	ascending _ oldPageNumber < pageIndex.
	oldPageNumber = pageIndex ifTrue: [ascending _ nil].

	(aWorld _ self world) ifNotNil:
		[self primaryHand newKeyboardFocus: nil].
	currentPage ifNotNil:
		[(oldRect _ currentPage screenRectangle) ifNotNil:
			[oldOrigin _ oldRect origin].
		currentPage releaseCachedState; delete].
	currentPage _ pages at: pageIndex.
	self addMorphBack: currentPage.
	aWorld ifNotNil:
		[self world startSteppingSubmorphsOf: currentPage.
		self showPageTurningFeedbackFromOrigin: oldOrigin ascending: ascending]