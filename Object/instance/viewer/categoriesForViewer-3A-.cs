categoriesForViewer: aViewer
	"Answer a list of symbols representing the categories of methods/inst vars for the receiver, for the given viewer.  The deeper functionality here has yet to be ported forward from earlier demos."

	| filter ivs |
	true ifTrue: [^ self class organization categories].

	filter _ aViewer filteringScheme.

	(filter == #minimal) ifTrue: [^ self class  minimalViewerCategoriesIn: aViewer].
	(filter == #myOwn) ifTrue: [^ self class rootViewerCategoriesIn: aViewer].
	(filter == #eToy) ifTrue: [^ self class etoyViewerCategoriesIn: aViewer].
	(filter == #custom) ifTrue: [^ self class customViewerCategoriesIn: aViewer].
	(filter == #most) ifTrue: [^ self class mostViewerCategoriesIn: aViewer].
	(filter == #standard) ifTrue: [^ self class standardViewerCategoriesIn: aViewer].
	(filter == #all) ifTrue: [^ self class allViewerCategoriesIn: aViewer].
	(filter == (ivs _ #instanceVariables)) ifTrue: [^ Array with: ivs].