buildClassListView: aBrowser

	| aClassListView |
	aClassListView _ ClassListView new.
	aClassListView model: aBrowser.
	aClassListView window: (0 @ 0 extent: 50 @ 62).
	aClassListView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	^aClassListView