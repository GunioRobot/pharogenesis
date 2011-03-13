lastUpdateNum: updatesFileStrm
	"Look in the Updates file and see what the last sequence number is.  Warn the user if the version it is under is not this image's version."

	| verIndex seqIndex char ver seqNum |
	verIndex _ seqIndex _ 0.	 "last # starting a line and last digit starting a line"
	seqNum _ 0.
	updatesFileStrm reset; ascii.
	[char _ updatesFileStrm next.
	 updatesFileStrm atEnd] whileFalse: [
		char == Character cr ifTrue: [
			updatesFileStrm peek == $# ifTrue: [verIndex _ updatesFileStrm position +1.
				seqIndex = 0 ifFalse: ["See if last num of old version if biggest so far"
					updatesFileStrm position: seqIndex.
					ver _ SmallInteger readFrom: updatesFileStrm.
					seqNum _ seqNum max: ver.
					updatesFileStrm position: verIndex-1]].
			updatesFileStrm peek isDigit ifTrue: [seqIndex _ updatesFileStrm position]]].

	seqIndex = 0 ifFalse: ["See if last num of old version if biggest so far"
		updatesFileStrm position: seqIndex.
		ver _ SmallInteger readFrom: updatesFileStrm.
		seqNum _ seqNum max: ver.
		updatesFileStrm setToEnd].
	^ seqNum