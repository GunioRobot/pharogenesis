initialize

	super initialize.

	transmitWhileRecording _ false.
	handsFreeTalking _ false.	
	mycodec _ GSMCodec new.
	myrecorder _ ChatNotes new.
	mytargetip _ ''.
	color _ Color yellow.
	borderWidth _ 4.
	borderColor _ Color black.
	self start2.
	self changeTalkButtonLabel.
	