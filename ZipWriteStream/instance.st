DeflateStream
	subclass: #ZipWriteStream
	instanceVariableNames: 'literals distances literalFreq distanceFreq litCount matchCount encoder '
	classVariableNames: 'VerboseLevel '
	poolDictionaries: 'ZipConstants '
	category: 'System-Compression'