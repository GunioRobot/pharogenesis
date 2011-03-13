updateAllViewersAndForceToShow: aCategory
	"The receiver's structure has changed, so viewers on it and all its siblings need to be reconstituted."

	| aPresenter |
	(aPresenter _ self costume presenter) ifNil: [^ self].
	self allOpenViewersOnReceiverAndSiblings do:
		[:aViewer | aPresenter updateViewer: aViewer forceToShow: aCategory]