writeArrayedCollection:aCollection
	self print:'/* '; print:aCollection class name; print:'*/'; cr.
	self print:'( '; writeCollectionContents:aCollection separator:','; print:')'.