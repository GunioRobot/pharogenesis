undoer: aSelector with: arg1
	"See comment in undoMessage:.  Use this version when aSelector has one argument, and you are doing or redoing and want to prepare for undoing."

	self undoMessage: (Message selector: aSelector argument: arg1) forRedo: false