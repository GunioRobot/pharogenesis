veryDeepFixupWith: deepCopier
	| old |
	"Any uniClass inst var may have been weakly copied.  If they were in the tree being copied, fix them up, otherwise point to the originals."

super veryDeepFixupWith: deepCopier.
Player instSize + 1 to: self class instSize do:
	[:ii | old _ self instVarAt: ii.
	self instVarAt: ii put: (deepCopier references at: old ifAbsent: [old])].
