installSourceFile: aStream
	"Install the previously loaded source file"
	| contents trusted |
	aStream ifNil:[^self error:'No content to install'].
	trusted _ SecurityManager default positionToSecureContentsOf: aStream.
	trusted ifFalse:[(SecurityManager default enterRestrictedMode) 
					ifFalse:[ aStream close.
							^ self error:'Insecure content encountered']].
	contents _ aStream ascii upToEnd unzipped.
	(aStream respondsTo: #close) ifTrue:[aStream close].
	^(RWBinaryOrTextStream with: contents) reset fileIn