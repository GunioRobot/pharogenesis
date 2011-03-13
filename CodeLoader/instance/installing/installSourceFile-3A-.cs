installSourceFile: aStream
	"Install the previously loaded source file"
	| contents secured |
	aStream ifNil:[^self error:'No content to install'].
	secured _ self positionedToSecuredContentsOf: aStream.

	secured
		ifFalse: [
			(aStream respondsTo: #close) ifTrue:[aStream close].
			^self error:'Insecure content encountered'].
	contents _ aStream upToEnd unzipped.
	(aStream respondsTo: #close) ifTrue:[aStream close].
	^(RWBinaryOrTextStream with: contents) reset fileIn