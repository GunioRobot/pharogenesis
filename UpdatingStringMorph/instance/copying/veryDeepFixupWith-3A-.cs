veryDeepFixupWith: deepCopier
	"If target field is weakly copied, fix it here.  If they were in the tree being copied, fix them up, otherwise point to the originals!!"

super veryDeepFixupWith: deepCopier.
target _ deepCopier references at: target ifAbsent: [target].
