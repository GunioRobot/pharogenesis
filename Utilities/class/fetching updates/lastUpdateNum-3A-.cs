lastUpdateNum: updatesFileStrm
	"Look in the Updates file and see what the last sequence number is.  Warn the user if the version it is under is not this image's version."

	| verIndex seqIndex char ver seqNum |
	verIndex := seqIndex := 0.	 "last # starting a line and last digit starting a line"
	seqNum := 0.
	updatesFileStrm reset; ascii.
	[char := updatesFileStrm next.
	 updatesFileStrm atEnd] whileFalse: [
		char == Character cr ifTrue: [
			updatesFileStrm peek == $# ifTrue: [verIndex := updatesFileStrm position +1.
				seqIndex = 0 ifFalse: ["See if last num of old version if biggest so far"
					updatesFileStrm position: seqIndex.
					ver := SmallInteger readFrom: updatesFileStrm.
					seqNum := seqNum max: ver.
					updatesFileStrm position: verIndex-1]].
			updatesFileStrm peek isDigit ifTrue: [seqIndex := updatesFileStrm position]]].

	seqIndex = 0 ifFalse: ["See if last num of old version if biggest so far"
		updatesFileStrm position: seqIndex.
		ver := SmallInteger readFrom: updatesFileStrm.
		seqNum := seqNum max: ver.
		updatesFileStrm setToEnd].
	^ seqNum