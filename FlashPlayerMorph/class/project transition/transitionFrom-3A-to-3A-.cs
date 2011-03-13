transitionFrom: srcProjectName to: dstProjectName
	"Return the transition between the two projects"
	| srcProject dstProject |

	srcProject := Project namedOrCurrent: srcProjectName.
	dstProject := Project namedOrCurrent: dstProjectName.
	^dstProject projectParameters at: #flashTransition ifPresent:[:dict|
		dict at: srcProject ifAbsent:[nil]].
