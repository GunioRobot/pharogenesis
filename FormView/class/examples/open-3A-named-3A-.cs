open: aForm named: aString
	"FormView open: (GIFReadWriter imageFromFileNamed: 'TylerCrop.GIF')
named: 'Squeak' "
	"Answer a scheduled view whose model is aForm and whose label is
aString. 12/11/96 tk"
	| topView aView |
	topView _ StandardSystemView new.
	topView model: aForm.
	topView label: aString.
	topView minimumSize: 80@80.
	aView _ FormView new.
	aView model: aForm.
	aView window: (0 @ 0 extent: aForm extent + (4@4)).
		"compensate for borders.  Should be window:viewport:"
	aView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	topView addSubView: aView.
	topView controller open