veryDeepFixupWith: deepCopier
	| old |
	"Any uniClass inst var may have been weakly copied.  If they were in the tree being copied, fix them up, otherwise point to the originals."

super veryDeepFixupWith: deepCopier.
myWonderland _ deepCopier references at: myWonderland ifAbsent: [myWonderland].
"myWonderland getNamespace at: myName put: self." 	"register me"
	"That does not register it, and the name structure is messed up by green-handle copy"

WonderlandActor instSize + 1 to: self class instSize do:
	[:ii | old _ self instVarAt: ii.
	self instVarAt: ii put: (deepCopier references at: old ifAbsent: [old])].
