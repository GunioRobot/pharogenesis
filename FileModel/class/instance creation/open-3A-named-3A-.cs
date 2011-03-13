open: aFileModel named: aString 
	"Answer a scheduled view whose model is aFileModel and whose label is aString. "

	| topView aView |
	topView _ StandardSystemView new.
	topView model: aFileModel.
	topView label: aString.
	topView minimumSize: 180 @ 120.
	aView _ FileView new.
	aView model: aFileModel.
	aView window: (0 @ 0 extent: 180 @ 120).
	aView
		borderWidthLeft: 2
		right: 2
		top: 2
		bottom: 2.
	topView addSubView: aView.
	topView controller open