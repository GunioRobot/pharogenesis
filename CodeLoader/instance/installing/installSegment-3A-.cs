installSegment: reqEntry
	"Install the previously loaded segment"
	| contentStream contents trusted |
	contentStream _ reqEntry value contentStream.
	contentStream ifNil:[^self error:'No content to install: ', reqEntry key printString].
	trusted _ SecurityManager default positionToSecureContentsOf: contentStream.
	trusted ifFalse:[(SecurityManager default enterRestrictedMode) ifFalse:[
		contentStream close.
		^self error:'Insecure content encountered: ', reqEntry key printString]].
	contents _ contentStream ascii upToEnd unzipped.
	(contentStream respondsTo: #close) ifTrue:[contentStream close].
	^(RWBinaryOrTextStream with: contents) reset fileInObjectAndCode install.