shutDown
	"System is going down. Internalize my bits and be finished."
	| copy |
	copy _ Form extent: self extent depth: self depth.
	self displayOn: copy.
	copy hibernate. "compact bits of copy"
	self destroy. "Release my external handle"
	bits _ copy bits. "Now compressed"
	display _ nil. "No longer allocated"
	argbMap _ nil. "No longer external"