buildOSTypeFromCharString: folderTypeData 
	"preserve platform endianness"

	^folderTypeData asByteArray unsignedLongAt: 1 bigEndian: true