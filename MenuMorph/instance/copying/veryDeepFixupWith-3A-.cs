veryDeepFixupWith: deepCopier
	"If fields were weakly copied, fix them here.  If they were in the tree being copied, fix them up, otherwise point to the originals."

super veryDeepFixupWith: deepCopier.
defaultTarget _ deepCopier references at: defaultTarget ifAbsent: [defaultTarget].
popUpOwner _ deepCopier references at: popUpOwner ifAbsent: [popUpOwner].
activeSubMenu _ deepCopier references at: activeSubMenu ifAbsent:[activeSubMenu].