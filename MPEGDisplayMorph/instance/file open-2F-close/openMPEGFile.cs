openMPEGFile
	"Invoked by the 'Open' button. Prompt for a file name and try to open that file as an MPEG file."

	| result |
	result _ (FileList2 modalFileSelectorForSuffixes: #('mp3' 'mpg' 'mpeg' 'jmv')) .
	result ifNil: [^ self].
	self stopPlaying.
	self openFileNamed: (result fullName).
