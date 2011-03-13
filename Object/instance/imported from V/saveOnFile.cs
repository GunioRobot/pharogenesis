saveOnFile
	"Ask the user for a filename and save myself on a ReferenceStream file.
	 11/13/92 jhm: Set the file type so it won't appear to be TEXT.
	 12/2/92 sw:  Stash ReferenceStream versionCode at start of file.
	Is this ever used???  7/26/96 tk"

	| aFileStream |

	aFileStream _ FileStream fromUser.
	aFileStream isNil ifTrue: [^ false].
	aFileStream binary.

	self aboutToWriteToDisk.

	(ReferenceStream on: aFileStream)
		nextPut: ReferenceStream versionCode;
		nextPut: self;
		setType;
		close.

	self doneWritingToDisk