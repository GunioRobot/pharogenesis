snapshot: save andQuit: quit
	"Mark the changes file and close all files.  If save is true, save the current state of this Smalltalk in the image file.  If quit is true, then exit to the outer shell.  Note: latter part of this method runs when resuming a previously saved image. 
	1/17/96 sw: ripped out the disk-library maintenance stuff
	5/8/96 sw: report snapshot/quit to transcript as well as chgs log"

	| resuming msg |
	save & (SourceFiles at: 2) notNil ifTrue:
		[msg _  (quit
			ifTrue: ['----QUIT----']
			ifFalse: ['----SNAPSHOT----']), Date dateAndTimeNow printString.

		self logChange: msg.
		Transcript cr; show: msg.
		LastQuitLogPosition _ (SourceFiles at: 2) position].

	self processShutDownList.
	Cursor write show.
	save ifTrue: [resuming _ self snapshotPrimitive]  "<-- PC frozen here on image file"
		ifFalse: [resuming _ false].
	quit & resuming not ifTrue: [self quitPrimitive].
	Cursor normal show.
	self processStartUpList.
	