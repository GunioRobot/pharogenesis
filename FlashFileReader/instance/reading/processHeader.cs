processHeader
	"Read header information from the source stream.
	Return true if successful, false otherwise."
	| twipsFrameSize frameRate frameCount |
	self processSignature ifFalse:[^false].
	version _ stream nextByte.
	"Check for the version supported"
	version > self maximumSupportedVersion ifTrue:[
		(self confirm:('This file''s version ({1}) is higher than 
the currently supported version ({2}). 
It may contain features that are not supported 
and it may not display correctly.
Do you want to continue?' translated format:{version. self maximumSupportedVersion})) ifFalse:[^false]].

	dataSize _ stream nextLong.
	"Check for the minimal file size"
	dataSize < 21 ifTrue:[^false].
	twipsFrameSize _ stream nextRect.
	self recordGlobalBounds: twipsFrameSize.
	frameRate _ stream nextWord / 256.0.
	self recordFrameRate: frameRate.
	frameCount _ stream nextWord.
	self recordFrameCount: frameCount.
	log ifNotNil:[
		log cr; nextPutAll:'------------- Header information --------------'.
		log cr; nextPutAll:'File version		'; print: version.
		log cr; nextPutAll:'File size			'; print: dataSize.
		log cr; nextPutAll:'Movie width		'; print: twipsFrameSize extent x // 20.
		log cr; nextPutAll:'Movie height	'; print: twipsFrameSize extent y // 20.
		log cr; nextPutAll:'Frame rate		'; print: frameRate.
		log cr; nextPutAll:'Frame count	'; print: frameCount.
		log cr; cr.
		self flushLog].
	^true