snapshot: save andQuit: quit
	"Mark the changes file and close all files. If save is true, save the current state of this Smalltalk in the image file. If quit is true, then exit to the outer shell. The latter part of this method runs when resuming a previously saved image. The resume logic checks for a document file to process when starting up."

	| resuming msg sourceLink |
	save & (SourceFiles at: 2) notNil ifTrue:
		[msg _  (quit
			ifTrue: ['----QUIT----']
			ifFalse: ['----SNAPSHOT----'])
			, Date dateAndTimeNow printString.
		sourceLink _ ' priorSource: ' , LastQuitLogPosition printString.

		LastQuitLogPosition _ (SourceFiles at: 2) setToEnd; position.
		self logChange: msg , sourceLink.
		Transcript cr; show: msg].

	self processShutDownList.
	Smalltalk isMorphic ifFalse: [Cursor write show].
	save
		ifTrue: [resuming _ self snapshotPrimitive]  "<-- PC frozen here on image file"
		ifFalse: [resuming _ false].
	quit & resuming not ifTrue: [self quitPrimitive].
	Smalltalk isMorphic ifFalse: [Cursor normal show].
	self processStartUpList.
	resuming ifTrue: [
		self clearExternalObjects.
		self readDocumentFile].
