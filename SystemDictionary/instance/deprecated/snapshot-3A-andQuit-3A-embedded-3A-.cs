snapshot: save andQuit: quit embedded: embeddedFlag
	"Mark the changes file and close all files. If save is true, save the current state of this Smalltalk in the image file. If quit is true, then exit to the outer shell. The latter part of this method runs when resuming a previously saved image. The resume logic checks for a document file to process when starting up."

	self deprecated: 'Use SmalltalkImage current snapshot: save andQuit: quit embedded: embeddedFlag'.
	SmalltalkImage current snapshot: save andQuit: quit embedded: embeddedFlag