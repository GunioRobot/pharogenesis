imporHyperSqueaktGIF
	"Import the file into a GIF file, into HyperSqueak. It had better be in the appropriate format, or you'll regret it!  Places the resulting form into the HyperSqueak picture library, at a key which the short filename up to the first period. 8/17/96 sw
	 9/18/96 sw: handle no-gif-reader and no-HyperSqueak cases with Informers"

	| aKey anImage hsq gifReader |
	Smalltalk hyperSqueakPresent ifFalse:
		[^ self inform: 'Sorry, HyperSqueak is not present in the current system.'].
	(gifReader _ Smalltalk gifReaderClass) == nil ifTrue: [^ self inform: 'Sorry, there is no GIF reader available in the current system.'].
	aKey _ self fileName sansPeriodSuffix.
	anImage _ gifReader imageFrom: (FileStream oldFileNamed: self fullName).
	(hsq _ Smalltalk at: #SqueakSupport ifAbsent: [nil]) == nil
		ifFalse:
			[hsq importPicture: anImage withKey: aKey]