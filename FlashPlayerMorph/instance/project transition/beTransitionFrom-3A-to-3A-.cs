beTransitionFrom: srcProjectName to: dstProjectName
	"Make the receiver the animation between the two projects"
	| srcProject dstProject |
	srcProject _ CurrentProjectRefactoring projectWithNameOrCurrent: srcProjectName.
	dstProject _ CurrentProjectRefactoring projectWithNameOrCurrent: dstProjectName.
	(dstProject projectParameters at: #flashTransition ifAbsentPut:[IdentityDictionary new])
		at: srcProject put: self.
