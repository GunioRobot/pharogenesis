importGIF
	"Import the file into a GIF file. It had better be in the appropriate format, or you'll regret it!  Places the resulting form into the global dictionary GIFImports, at a key which the short filename up to the first period.  7/18/96 sw
	 9/18/96 sw: fail gracefully if GIF is missing."

	| aKey anImage gifReader |
	(gifReader _ Smalltalk gifReaderClass) == nil ifTrue: [^ self inform: 'Sorry, there is no GIF reader available in the current system.'].
	aKey _ self fileName sansPeriodSuffix.
	anImage _ gifReader imageFrom: (FileStream oldFileNamed: self fullName).
	Smalltalk gifImports at: aKey put: anImage