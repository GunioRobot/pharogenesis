veryDeepFixupWith: deepCopier 
	"If target and arguments fields were weakly copied, fix them here.  If 
	they were in the tree being copied, fix them up, otherwise point to the 
	originals!"

	super veryDeepFixupWith: deepCopier.
	"Caller beware: it makes no sense to share pointers to existing predecessor and successor"
	predecessor _ deepCopier references at: predecessor ifAbsent: [].
	successor _ deepCopier references at: successor ifAbsent: []