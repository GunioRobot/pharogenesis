undoer: aSelector
	"See comment in undoMessage:.  Use this version when aSelector has no arguments, and you are doing or redoing and want to prepare for undoing."

	self undoMessage: (Message selector: aSelector) forRedo: false