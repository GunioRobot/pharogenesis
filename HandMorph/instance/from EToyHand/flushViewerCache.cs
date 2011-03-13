flushViewerCache
	| aPresenter |
	aPresenter _ argument isMorph ifTrue: [argument presenter] ifFalse: [owner presenter].
	aPresenter ifNotNil:
		[aPresenter flushViewerCache]