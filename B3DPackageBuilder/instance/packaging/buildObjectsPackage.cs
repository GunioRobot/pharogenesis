buildObjectsPackage
	"Build the Alice objects package"
	| postscript zip mbr |
	zip := ZipArchive new.
	postscript := String new writeStream.
	Utilities informUserDuring:[:bar|
		self filesIn: #('alice') do:[:filename|
			bar value: 'Adding ', filename.
			zip addMember: ((ZipArchiveMember newFromFile: filename) fileName: filename; yourself).
		].
	].
	zip addMember: (mbr := ZipArchiveMember newFromString: postscript contents
				named: 'install/postscript').
	mbr desiredCompressionMethod: 8. "DEFLATE"
	zip writeToFileNamed: 'Balloon3DObjects.sar'.
	zip close.
