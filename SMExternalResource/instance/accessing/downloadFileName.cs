downloadFileName
	"Cut out the filename from the url."

	downloadUrl isEmpty ifTrue: [^nil].
	^downloadUrl asUrl path last