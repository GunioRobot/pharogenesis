putCommentOnFile: aFileStream numbered: sourceIndex moveSource: moveSource forClass: aClass
	"Store the comment about the class onto file, aFileStream."

	| commentRemoteStr header |
	commentRemoteStr _ aClass organization commentRemoteStr.
	commentRemoteStr ifNotNil:
		[aFileStream cr; nextPut: $!.
		"Should be saying (file command: 'H3') for HTML, but ignoring it here (tck's note)"
		header _ String streamContents: [:strm | 
				strm nextPutAll: aClass name;
				nextPutAll: ' commentStamp: '.
				Utilities changeStamp storeOn: strm.
				strm nextPutAll: ' prior: '; nextPutAll: '0'].
		aFileStream nextChunkPut: header; cr.
		RemoteString newString: commentRemoteStr text
				onFileNumber: nil
				toFile: aFileStream.
		aFileStream cr]