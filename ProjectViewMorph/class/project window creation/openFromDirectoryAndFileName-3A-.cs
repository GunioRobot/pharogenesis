openFromDirectoryAndFileName: anArray
	
	Project canWeLoadAProjectNow ifFalse: [^ self].
	^ProjectLoading 
		openFromDirectory: anArray first 
		andFileName: anArray second