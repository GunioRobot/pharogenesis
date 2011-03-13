tryToFindAServerWithMe

	| servers resp primaryServerDirectory |

	urlList isEmptyOrNil ifTrue: [urlList _ parentProject urlList copy].
	[(servers _ self serverList) isNil] whileTrue: [
		resp _ (PopUpMenu labels: 'Try to find a server\Cancel' withCRs) startUpWithCaption: 
					'This project thinks it has never been on a server'.
		resp ~= 1 ifTrue: [^ nil].
		(primaryServerDirectory _ self findAFolderToLoadProjectFrom) ifNil: [^nil].
		self storeNewPrimaryURL: primaryServerDirectory realUrl, '/'.
	].
	^servers
