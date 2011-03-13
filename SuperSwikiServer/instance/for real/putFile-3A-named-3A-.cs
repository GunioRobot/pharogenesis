putFile: fileStream named: fileNameOnServer

	^(
		self sendToSwikiProjectServer: {
			'uploadproject: ',fileNameOnServer.
			fileStream contentsOfEntireFile.
		}
	) beginsWith: 'OK'
