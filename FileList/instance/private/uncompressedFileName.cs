uncompressedFileName
	| f |
	f _ self fullName.
	((f endsWith: '.gz') and: [self confirm: f , '
appears to be a compressed file.
Do you want to uncompress it?'])
		ifFalse: [^ f].
	^ self saveGZipContents