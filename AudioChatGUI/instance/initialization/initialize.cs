initialize
	"initialize the state of the receiver"
	super initialize.
	""
	transmitWhileRecording _ false.
	handsFreeTalking _ false.
	mycodec _ GSMCodec new.
	myrecorder _ ChatNotes new.
	mytargetip _ ''.
	
	self start2.
	self changeTalkButtonLabel