writeImageFile: imageBytes

	| headerStart headerSize f bytesWritten sCWIfn okToWrite |
	self var: #f declareC: 'sqImageFile f'.
	self var: #headerStart declareC: 'squeakFileOffsetType headerStart'.

	"If the security plugin can be loaded, use it to check for write permission.
	If not, assume it's ok"
	sCWIfn _ self ioLoadFunction: 'secCanWriteImage' From: 'SecurityPlugin'.
	sCWIfn ~= 0 ifTrue:[okToWrite _ self cCode:' ((int (*) (void)) sCWIfn)()'.
		okToWrite ifFalse:[^self primitiveFail]].
	
	"local constants"
	headerStart _ 0.  
	headerSize _ 64.  "header size in bytes; do not change!"

	f _ self cCode: 'sqImageFileOpen(getImageName(), "wb")'.
	f = nil ifTrue: [
		"could not open the image file for writing"
		self success: false.
		^ nil].

	headerStart _ self cCode: 'sqImageFileStartLocation(f,getImageName(),headerSize+imageBytes)'.
	self cCode: '/* Note: on Unix systems one could put an exec command here, padded to 512 bytes */'.
	"position file to start of header"
	self sqImageFile: f Seek: headerStart.

	self putLong: (self imageFormatVersion) toFile: f.
	self putLong: headerSize toFile: f.
	self putLong: imageBytes toFile: f.
	self putLong: (self startOfMemory) toFile: f.
	self putLong: specialObjectsOop toFile: f.
	self putLong: lastHash toFile: f.
	self putLong: (self ioScreenSize) toFile: f.
	self putLong: fullScreenFlag toFile: f.
	self putLong: extraVMMemory toFile: f.
	1 to: 7 do: [:i | self putLong: 0 toFile: f].  "fill remaining header words with zeros"
	successFlag ifFalse: [
		"file write or seek failure"
		self cCode: 'sqImageFileClose(f)'.
		^ nil].

	"position file after the header"
	self sqImageFile: f Seek: headerStart + headerSize.

	"write the image data"
	bytesWritten _ self cCode: 'sqImageFileWrite(memory, sizeof(unsigned char), imageBytes, f)'.
	self success: bytesWritten = imageBytes.
	self cCode: 'sqImageFileClose(f)'.

