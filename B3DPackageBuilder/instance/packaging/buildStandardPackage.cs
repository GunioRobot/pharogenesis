buildStandardPackage
	"B3DPackageBuilder buildStandardPackage"
	"Build the standard Balloon3D package"
	| postscript zip fileName fileOut mbr prelude pi |
	zip := ZipArchive new.
	prelude := String new writeStream.
	prelude nextPutAll: self preludeString.
	postscript := String new writeStream.
	postscript nextPutAll: self postscriptString.
	Utilities informUserDuring:[:bar|
		self packageNames do:[:pkgName|
			bar value: 'Adding ', pkgName.
			pi := packageInfo named: pkgName.
			fileName := pkgName,'.st'.
			fileOut := String streamContents:[:s| 
				(self asChangeSet: pi named: pkgName) fileOutOn: s].
			zip addMember: (mbr := ZipArchiveMember newFromString: fileOut named: fileName).
			mbr desiredCompressionMethod: 8. "DEFLATE"
			postscript 
				nextPutAll: 'self fileInMemberNamed: '; store: fileName; nextPutAll:'.';
				cr.
		].
	].

	self addExtraObjectsTo: zip.
	postscript nextPutAll: 'Wonderland initializeDefaultObjectsFrom: self zip.'; cr.
	postscript nextPutAll: 'B3DTutorialPresenter openTutorial.'; cr.
	postscript nextPutAll: 'DataStream initialize.'; cr.
	zip addMember: (mbr := ZipArchiveMember newFromString: postscript contents
				named: 'install/postscript').
	mbr desiredCompressionMethod: 8. "DEFLATE"
	zip addMember: (mbr := ZipArchiveMember newFromString: prelude contents
				named: 'install/preamble').
	mbr desiredCompressionMethod: 8. "DEFLATE"
	Cursor write showWhile:[zip writeToFileNamed: 'Balloon3D.sar'].
	zip close.