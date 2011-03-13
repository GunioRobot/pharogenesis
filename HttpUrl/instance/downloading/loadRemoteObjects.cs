loadRemoteObjects
	"Load a remote image segment and extract the root objects.
	Check if the remote file is a zip archive."
	"'http://bradley.online.disney.com/games/subgame/squeak-test/assetInfo.extSeg' 
		asUrl loadRemoteObjects" 
	"'http://bradley.online.disney.com/games/subgame/squeak-test/assetInfo.zip' 
		asUrl loadRemoteObjects" 

	| stream info data extension |
 	data _ self retrieveContents content.
	extension _ (FileDirectory extensionFor: self path last) asLowercase.
	(#('zip' 'gzip') includes: extension)
		ifTrue: [data _ (GZipReadStream on: data) upToEnd].
"	stream _ StreamWrapper streamOver: (ReadStream on: data)."
	stream _ RWBinaryOrTextStream on: data.
	stream reset.
	info _ stream fileInObjectAndCode.
	stream close.
	^info arrayOfRoots