changeStamp
	"Answer a string to be pasted into source code to mark who changed it and when.  1/17/96 sw"
	^ Date today mmddyy, ' ', self authorInitials