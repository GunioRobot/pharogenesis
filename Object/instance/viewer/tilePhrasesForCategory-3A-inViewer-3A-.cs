tilePhrasesForCategory: aCategorySymbol inViewer: aViewer
	"Return a collection of phrases for the category."

	| interfaces |
	interfaces _ self methodInterfacesForCategory: aCategorySymbol inVocabulary: aViewer currentVocabulary limitClass: aViewer limitClass.
	interfaces _ self methodInterfacesInPresentationOrderFrom: interfaces forCategory: aCategorySymbol.
	^ self tilePhrasesForMethodInterfaces: interfaces inViewer: aViewer