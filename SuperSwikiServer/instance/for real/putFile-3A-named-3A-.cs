putFile: fileStream named: fileNameOnServer

	
	^(
		self sendToSwikiProjectServer: {
			'uploadproject: ',fileNameOnServer convertToSuperSwikiServerString.
			'password: ',ProjectPasswordNotification signal.
			fileStream contentsOfEntireFile.
		}
	) beginsWith: 'OK'
