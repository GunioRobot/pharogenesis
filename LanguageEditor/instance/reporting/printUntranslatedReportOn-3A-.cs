printUntranslatedReportOn: aStream 
	"append to aStream a report of the receiver's translations"
	aStream nextPutAll: '!';
		 nextPutAll: 'not translated' translated;
		 cr.

	self untranslated asSortedCollection
		do: [:each | 
			aStream
				nextPutAll: ('|{1}|' format: {self asHtml: each});
				 cr].

	aStream cr; cr