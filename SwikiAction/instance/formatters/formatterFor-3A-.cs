formatterFor: formatterName
	"get the formatter for the given name.  uses lazy initialization.  Could eventually check whether the on-disk file has been updated."
	
	
	"first, create the dictionary of formatters if it isn't already"
	formatters == nil ifTrue: [
		formatters _ Dictionary new. ].

	"create the formatter if necessary"
	^formatters at: formatterName ifAbsent: [
		formatters at: formatterName put: 
			(HTMLformatter forEvaluatingEmbedded: (self fileContents: (source, formatterName, '.html'))).
	].

