fileInObjectAndCode
	"Optimization: Read entire file into memory before processing."

	| s |
	self text.
	s _ RWBinaryOrTextStream with: (self contentsOfEntireFile).
	s position: 0.
	^ s fileInObjectAndCode
