upLoadProject: projectName members: archiveMembers retry: aBool
	| answer |
	archiveMembers do:[:entry|
		ProgressNotification signal: '4:uploadingFile' extra:'(uploading ' translated, entry fileName convertFromSystemString , '...)' translated.
		answer _ self sendToSwikiProjectServer: {
			'uploadproject2: ', entry fileName convertFromSystemString convertToSuperSwikiServerString.
			'password: ',ProjectPasswordNotification signal.
			entry contents.
		}.
		answer = 'OK' ifFalse:[
			self inform:'Server responded ' translated, answer.
			^false].
	].
	ProgressNotification signal: '4:uploadingFile' extra:''.
	^true