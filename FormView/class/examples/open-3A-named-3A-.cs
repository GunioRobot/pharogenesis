open: aForm named: aString
	"FormView open: ((Form extent: 100@100) borderWidth: 1) named: 'Squeak' "
	"Open a window whose model is aForm and whose label is aString."
	| topView aView |
	topView _ StandardSystemView new.
	topView model: aForm.
	topView label: aString.
	topView minimumSize: aForm extent;
	          maximumSize: aForm extent.
	aView _ FormView new.
	aView model: aForm.
	aView window: (aForm boundingBox expandBy: 2).
	aView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	topView addSubView: aView.
	topView controller open