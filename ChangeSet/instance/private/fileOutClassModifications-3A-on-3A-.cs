fileOutClassModifications: class on: stream 
	"Write out class mod-- rename, comment, reorg, remove, on the given stream.  Differs from the superseded fileOutClassChanges:on: in that it does not deal with class definitions, and does not file out entire added classes.  
	 : put out a rename indicator that won't halt if class of old name not there."

	| commentRemoteStr header |
	(self atClass: class includes: #rename) ifTrue:
		[stream nextChunkPut: 'Smalltalk renameClassNamed: #', (self oldNameFor: class), ' as: #', class name; cr].

	(self atClass: class includes: #comment) ifTrue:
		[commentRemoteStr _ class theNonMetaClass organization commentRemoteStr.
		commentRemoteStr ifNotNil: [
			stream cr; nextPut: $!.	"directly"
			"Should be saying (file command: 'H3') for HTML, but ignoring it here"
			header _ String streamContents: [:strm | 
				strm nextPutAll: class theNonMetaClass name;
				nextPutAll: ' commentStamp: '.
				Utilities changeStamp storeOn: strm.
				strm nextPutAll: ' prior: '; nextPutAll: '0'].
			stream nextChunkPut: header; cr.

			RemoteString
				newString: commentRemoteStr text
				onFileNumber: nil
				toFile: stream.
			stream cr]].

	(self atClass: class includes: #reorganize) ifTrue:
		[class fileOutOrganizationOn: stream.
		stream cr]