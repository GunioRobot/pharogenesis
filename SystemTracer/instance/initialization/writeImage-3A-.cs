writeImage: roots 
	imageHeaderSize _ 64.	"16 longs"
	file position: imageHeaderSize.  "Skip header section"
	maxOop _ 0.  "Starting oop"
	self initCompactClasses.
	specialObjects _ Smalltalk specialObjectsArray copy.
	specialObjects at: 29 put: compactClasses.
	"New oop of nil is needed before we find out from the trace."
	NewNil _ maxOop + ((self headersFor: nil withHash: 0) size-1*4).
	self trace: nil.  "In fact, this traverses the system by the time it's done!"
	self trace: specialObjects.
	roots do: [:root | self trace: root].
	self writeFileHeader.
	^ Array with: maxOop