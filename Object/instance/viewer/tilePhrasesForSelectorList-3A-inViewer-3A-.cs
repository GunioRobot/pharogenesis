tilePhrasesForSelectorList: aList inViewer: aViewer
	"Particular to the search facility in viewers.  Answer a list, in appropriate order, of ViewerLine objects to put into the viewer."

	| interfaces aVocab |
	aVocab _ aViewer currentVocabulary.
	interfaces _ self
		methodInterfacesInPresentationOrderFrom:
			(aList collect: [:aSel | aVocab methodInterfaceForSelector: aSel class: self class])
		forCategory: #search.
	^ self tilePhrasesForMethodInterfaces: interfaces inViewer: aViewer