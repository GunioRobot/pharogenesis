snapshot: save andQuit: quit
	"Mark the changes file and close all files. If save is true, save the current state of this Smalltalk in the image file. If quit is true, then exit to the outer shell. The latter part of this method runs when resuming a previously saved image. The resume logic checks for a document file to process when starting up."

	| resuming msg sourceLink |
	save & (SourceFiles at: 2) notNil ifTrue:
		[msg _  (quit
			ifTrue: ['----QUIT----']
			ifFalse: ['----SNAPSHOT----'])
			, Date dateAndTimeNow printString.
		sourceLink _ ' priorSource: ' , LastQuitLogPosition printString.
		self assureStartupStampLogged.
		LastQuitLogPosition _ (SourceFiles at: 2) setToEnd; position.
		self logChange: msg , sourceLink.
		Transcript cr; show: msg].

	self processShutDownList: quit.
	Cursor write show.
	save ifTrue: [resuming _ self snapshotPrimitive.  "<-- PC frozen here on image file"
				resuming ifFalse:
					["Time to reclaim segment files is immediately after a save"
					Smalltalk at: #ImageSegment
						ifPresent: [:theClass | theClass reclaimObsoleteSegmentFiles]]]
		ifFalse: [resuming _ false].
	quit & resuming not ifTrue: [self quitPrimitive].
	Cursor normal show.
	self setGCParameters.
	resuming ifTrue: [self clearExternalObjects].
	self processStartUpList: resuming.
	resuming ifTrue:
		[self readDocumentFile].
	Smalltalk isMorphic ifTrue: [SystemWindow wakeUpTopWindowUponStartup].
	^ resuming