next
	"Answer the next object in the stream. If this object was already read by a
	 forward ref, don't re-read it. Cf. class comment. -- 11/18-24/92 jhm"
	| curPosn skipToPosn |

	"Did we already read the next object? If not, use ordinary super next."
	skipToPosn _ fwdRefEnds removeKey: (curPosn _ byteStream position)
							 ifAbsent: [nil].
	skipToPosn == nil ifTrue: [^ super next].
		"Compared to ifAbsent: [^ super next], this saves 2 stack frames per cycle
		 in the normal case of this deep recursion. This is mainly a debugging aid
		 but it also staves off stack overflow."

	"Skip over the object and return the already-read-in value from 'object'."
	byteStream position: skipToPosn.
	^ objects at: curPosn ifAbsent: [self errorInternalInconsistency]