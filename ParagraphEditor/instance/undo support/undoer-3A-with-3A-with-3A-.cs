undoer: aSelector with: arg1 with: arg2
	"See comment in undoMessage:.  Use this version when aSelector has two arguments, and you are doing or redoing and want to prepare for undoing."

	self undoMessage: (Message selector: aSelector arguments: (Array with: arg1 with: arg2)) forRedo: false