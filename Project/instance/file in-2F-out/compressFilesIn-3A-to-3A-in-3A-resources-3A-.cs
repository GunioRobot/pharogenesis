compressFilesIn: tempDir to: localName in: localDirectory resources: collector
	"Compress all the files in tempDir making up a zip file in localDirectory named localName"
	| archive entry urlMap archiveName |
	urlMap _ Dictionary new.
	collector locatorsDo:[:loc|
		"map local file names to urls"
		urlMap at: (tempDir localNameFor: loc localFileName) put: loc urlString.
		ResourceManager cacheResource: loc urlString inArchive: localName].
	archive _ ZipArchive new.
	tempDir fileNames do:[:fn|
		archiveName _ urlMap at: fn ifAbsent:[fn].
		entry _ archive addFile: (tempDir fullNameFor: fn) as: archiveName.
		entry desiredCompressionMethod: ZipArchive compressionStored.
	].
	archive writeToFileNamed: (localDirectory fullNameFor: localName).
	archive close.
	tempDir fileNames do:[:fn|
		tempDir deleteFileNamed: fn ifAbsent:[]].
	localDirectory deleteDirectory: tempDir localName.