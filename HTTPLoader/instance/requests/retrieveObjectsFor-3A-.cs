retrieveObjectsFor: aURL
	"Load a remote image segment and extract the root objects.
	Check if the remote file is a zip archive."
	"'http://bradley.online.disney.com/games/subgame/squeak-test/assetInfo.extSeg' 
		asUrl loadRemoteObjects" 
	"'http://bradley.online.disney.com/games/subgame/squeak-test/assetInfo.zip' 
		asUrl loadRemoteObjects" 

	| stream info data |
 	data _ self retrieveContentsFor: aURL.
	(data isString)
		ifTrue: [^self error: data]
		ifFalse: [data _ data content].
	(data beginsWith: 'error')
		ifTrue: [^self error: data].
	data _ data unzipped.
	stream _ RWBinaryOrTextStream on: data.
	stream reset.
	info _ stream fileInObjectAndCode.
	stream close.
	^info originalRoots