writeCollection:aCollection
	^self print:aCollection class name; 
		writeCollectionContents:aCollection.

