transitionFrom: srcProjectName to: dstProjectName
	"Return the transition between the two projects"
	| srcProject dstProject |

	srcProject _ CurrentProjectRefactoring projectWithNameOrCurrent: srcProjectName.
	dstProject _ CurrentProjectRefactoring projectWithNameOrCurrent: dstProjectName.
	^dstProject projectParameters at: #flashTransition ifPresent:[:dict|
		dict at: srcProject ifAbsent:[nil]].
