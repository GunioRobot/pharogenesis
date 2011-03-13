goToPageMorph: newPage transitionSpec: transitionSpec
	| pageIndex aWorld oldPageIndex ascending tSpec readIn |
	pages isEmpty ifTrue: [^ self].

	self setProperty: #searchContainer toValue: nil.	"forget previous search"
	self setProperty: #searchOffset toValue: nil.
	self setProperty: #searchKey toValue: nil.
	pageIndex _ pages identityIndexOf: newPage ifAbsent: [^ self "abort"].
	readIn _ newPage isInMemory not.
	oldPageIndex _ pages identityIndexOf: currentPage ifAbsent: [nil].
	ascending _ ((oldPageIndex == nil) or: [newPage == currentPage])
			ifTrue: [nil]
			ifFalse: [oldPageIndex < pageIndex].

	tSpec _ transitionSpec ifNil:  "If transition not specified by requestor..."
		[newPage valueOfProperty: #transitionSpec  " ... then consult new page"
			ifAbsent: [self transitionSpecFor: self  " ... otherwise this is the default"]].

	self flag: #arNote. "Probably unnecessary"
	(aWorld _ self world) ifNotNil:
		[self primaryHand releaseKeyboardFocus].

	currentPage ifNotNil: [currentPage updateCachedThumbnail].
	self currentPage ~~ nil
		ifTrue:
		[(((pages at: pageIndex) owner isKindOf: TransitionMorph)
			and: [(pages at: pageIndex) isInWorld])
			ifTrue: [^ self  "In the process of a prior pageTurn"].
		self currentPlayerDo: [:aPlayer | aPlayer runAllClosingScripts].
		ascending ifNotNil:
			["Show appropriate page transition and start new page when done"
			currentPage stopStepping.
			(pages at: pageIndex) position: currentPage position.
			^ (TransitionMorph
					effect: tSpec second
					direction: tSpec third
					inverse: (ascending or: [transitionSpec notNil]) not)
				showTransitionFrom: currentPage
				to: (pages at: pageIndex)
				in: self
				whenStart: [self playPageFlipSound: tSpec first]
				whenDone:
					[currentPage delete; fullReleaseCachedState.
					self insertPageMorphInCorrectSpot: (pages at: pageIndex).
					self adjustCurrentPageForFullScreen.
					self snapToEdgeIfAppropriate.
					aWorld ifNotNil: [self world startSteppingSubmorphsOf: currentPage].
					self currentPlayerDo: [:aPlayer | aPlayer runAllOpeningScripts].
					(aWorld _ self world) ifNotNil: ["WHY??" aWorld displayWorld].
					readIn ifTrue: [currentPage updateThumbnailUrlInBook: self url.
						currentPage sqkPage computeThumbnail].	"just store it"
					]].

		"No transition, but at least decommission current page"
		currentPage delete; fullReleaseCachedState].

	self insertPageMorphInCorrectSpot: (pages at: pageIndex).
	self adjustCurrentPageForFullScreen.
	self snapToEdgeIfAppropriate.
	aWorld ifNotNil: [self world startSteppingSubmorphsOf: currentPage].
	self currentPlayerDo: [:aPlayer | aPlayer runAllOpeningScripts].
	(aWorld _ self world) ifNotNil: ["WHY??" aWorld displayWorld].
	readIn ifTrue: [currentPage updateThumbnailUrl.
		currentPage sqkPage computeThumbnail].	"just store it"

