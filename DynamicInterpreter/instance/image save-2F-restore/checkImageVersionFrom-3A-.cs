checkImageVersionFrom: f
	"Read and verify the image file version number and return true if the the given image file needs to be byte-swapped. As a side effect, position the file stream just after the version number of the image header. This code prints a warning and does a hard-exit if it cannot find a valid version number."
	"This code is based on C code by Ian Piumarta."

	| expectedVersion version firstVersion |
	self var: #f declareC: 'sqImageFile f'.
	expectedVersion _ self imageFormatVersion.

	"check the version number"
	self sqImageFile: f Seek: 0.
	version _ firstVersion _ self getLongFromFile: f swap: false.
	version = expectedVersion ifTrue: [^ false].

	"try with byte reversal"
	self sqImageFile: f Seek: 0.
	version _ self getLongFromFile: f swap: true.
	version = expectedVersion ifTrue: [^ true].

	"try skipping the first 512 bytes (prepended by certain Mac file transfer utilities)"
	self sqImageFile: f Seek: 512.
	version _ self getLongFromFile: f swap: false.
	version = expectedVersion ifTrue: [^ false].

	"try skipping the first 512 bytes with byte reversal"
	self sqImageFile: f Seek: 512.
	version _ self getLongFromFile: f swap: true.
	version = expectedVersion ifTrue: [^ true].

	"hard failure; abort"
	self print: 'This interpreter (vers. '.
	self printNum: expectedVersion.
	self print: ' cannot read image file (vers. '.
	self printNum: firstVersion.
	self cr.
	self ioExit.
