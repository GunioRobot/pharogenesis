processFileAsync
	"Read and process the entire file"
	self processHeader ifFalse:[^nil].
	player sourceUrl:'dummy'.
	[self processFileContents] fork.
	^player