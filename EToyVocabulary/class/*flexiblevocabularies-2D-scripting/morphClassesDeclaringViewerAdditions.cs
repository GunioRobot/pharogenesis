morphClassesDeclaringViewerAdditions
	"Answer a list of actual morph classes that either implement #additionsToViewerCategories,
	or that have methods that match #additionToViewerCategory* ."

	^(Morph class allSubInstances select: [ :ea | ea hasAdditionsToViewerCategories ])
