startRunningScripts

	self stopButtonState: false.
	self stepButtonState: false.
	self goButtonState: true.
	goButton world startRunningAll.

	ThumbnailMorph recursionReset.  "needs to be done once in a while"