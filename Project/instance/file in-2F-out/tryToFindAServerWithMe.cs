tryToFindAServerWithMe

	| resp primaryServerDirectory |

	urlList isEmptyOrNil ifTrue: [urlList _ parentProject urlList copy].
	[self primaryServer isNil] whileTrue: [
		resp _ (UIManager default 
					chooseFrom: #('Try to find a server' 'Cancel')
					title: 'This project thinks it has never been on a server').
		resp ~= 1 ifTrue: [^ nil].
		(primaryServerDirectory _ self findAFolderToLoadProjectFrom) ifNil: [^nil].
		self storeNewPrimaryURL: primaryServerDirectory downloadUrl.
	].
	^self primaryServer
