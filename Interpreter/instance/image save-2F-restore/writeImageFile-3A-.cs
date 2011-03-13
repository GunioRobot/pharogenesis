writeImageFile: imageBytes
	| fn |
	self writeImageFileIO: imageBytes.

	"set Mac file type and creator; this is a noop on other platforms"
	fn _ self ioLoadFunction: 'setMacFileTypeAndCreator' From: 'FilePlugin'.
	fn = 0 ifFalse:[
		self cCode:'((int (*) (char*, char*, char*)) fn) (imageName, "STim", "FAST")'.
	].
