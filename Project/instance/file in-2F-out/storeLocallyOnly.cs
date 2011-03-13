storeLocallyOnly
	"Forget where stored before, and store.  Will ask user where."

	self forgetExistingURL.
	self validateProjectNameIfOK: [
		self isCurrentProject ifTrue: ["exit, then do the command"
			^ self 
				armsLengthCommand: #storeLocallyWithProgressInfo
				withDescription: 'Publishing'
		].
		self storeLocallyWithProgressInfo.
	].
