printTranslationsReportOn: aStream 
	"append to aStream a report of the receiver's translations"
	| originalPhrases |
	aStream nextPutAll: '!';
		 nextPutAll: 'translations' translated;
		 cr.

	originalPhrases := self translator translations keys asSortedCollection.

	originalPhrases
		do: [:each | 
			aStream
				nextPutAll: ('|{1}|{2}|' format: {self asHtml: each. self
							asHtml: (self translator translationFor: each)});
				 cr].

	aStream cr; cr