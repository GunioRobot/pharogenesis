updateAllViewers
	"The receiver's structure has changed, so viewers on it need to be reconstituted."
	| aPresenter |
	(aPresenter _ self costume presenter) ifNil: [^ self].
	self allOpenViewers do:
		[:aViewer | aPresenter updateViewer: aViewer]