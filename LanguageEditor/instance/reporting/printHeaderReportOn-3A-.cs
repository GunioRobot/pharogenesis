printHeaderReportOn: aStream 
	"append to aStream a header report of the receiver with swiki  
	format"
	aStream nextPutAll: '!!';
		
		nextPutAll: ('Language: {1}' translated format: {self translator localeID isoString});
		 cr.

	aStream nextPutAll: '- ';
		
		nextPutAll: ('{1} translated phrases' translated format: {self translator translations size});
		 cr.

	aStream nextPutAll: '- ';
		
		nextPutAll: ('{1} untranslated phrases' translated format: {self translator untranslated size});
		 cr.

	aStream cr; cr