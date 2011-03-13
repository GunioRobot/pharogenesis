installSegment: reqEntry
	"Install the previously loaded segment"
	| secured contentStream contents |
	contentStream _ reqEntry value contentStream.
	contentStream ifNil:[^self error:'No content to install: ', reqEntry key printString].
	secured _ self positionedToSecuredContentsOf: contentStream.

	secured
		ifFalse: [
			(contentStream respondsTo: #close) ifTrue:[contentStream close].
			^self error:'Insecure content encountered: ', reqEntry key printString].
	contents _ contentStream upToEnd unzipped.
	(contentStream respondsTo: #close) ifTrue:[contentStream close].
	^(RWBinaryOrTextStream with: contents) reset fileInObjectAndCode install.