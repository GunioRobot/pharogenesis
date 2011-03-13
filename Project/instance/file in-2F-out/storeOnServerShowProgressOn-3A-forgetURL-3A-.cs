storeOnServerShowProgressOn: aMorphOrNil forgetURL: forget

	"Save to disk as an Export Segment.  Then put that file on the server I came from, as a new version.  Version is literal piece of file name.  Mime encoded and http encoded."

	forget ifTrue: [
		self forgetExistingURL.
	] ifFalse: [
		urlList isEmptyOrNil ifTrue: [urlList _ parentProject urlList copy].
	].
	world setProperty: #optimumExtentFromAuthor toValue: world extent.
	self validateProjectNameIfOK: [
		self isCurrentProject ifTrue: ["exit, then do the command"
			^self
				armsLengthCommand: #storeOnServerAssumingNameValid
				withDescription: 'Publishing'
		].
		self storeOnServerWithProgressInfoOn: aMorphOrNil.
	] fixTemps.
