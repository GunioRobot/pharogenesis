lastUpdateNum: updatesFileStrm
	"Look in the Updates file and see what the last sequence number is.  Warn the user if the version it is under is not this image's version."

	| verIndex seqIndex char ver fileVer response |
	verIndex _ seqIndex _ 0.	 "last # starting a line and last digit starting a line"
	updatesFileStrm reset; ascii.
	[char _ updatesFileStrm next.
	 updatesFileStrm atEnd] whileFalse: [
		char == Character cr ifTrue: [
			updatesFileStrm peek == $# ifTrue: [verIndex _ updatesFileStrm position +1].
			updatesFileStrm peek isDigit ifTrue: [seqIndex _ updatesFileStrm position]]].
	updatesFileStrm position: seqIndex.
	ver _ 0.
	[char _ updatesFileStrm next.
	 char isDigit 
		ifTrue: [ver _ ver*10 + char digitValue.  true]
		ifFalse: [false]
			] whileTrue.
	updatesFileStrm position: verIndex.
	fileVer _ updatesFileStrm upTo: Character cr.
	(Smalltalk at: #EToySystem) version = fileVer ifFalse: [
		response _ (PopUpMenu labels: 'OK, Update is for latest system\Cancel update' withCRs)
			startUpWithCaption: 'Update will apply to version ', fileVer, ', but this system is ',
				(Smalltalk at: #EToySystem) version.
		response = 1 ifFalse: [^ nil]].	"abort"
	^ ver