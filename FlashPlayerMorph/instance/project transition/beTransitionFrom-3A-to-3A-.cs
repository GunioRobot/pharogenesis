beTransitionFrom: srcProjectName to: dstProjectName
	"Make the receiver the animation between the two projects"
	| srcProject dstProject |
	srcProject := Project namedOrCurrent: srcProjectName.
	dstProject := Project namedOrCurrent: dstProjectName.
	(dstProject projectParameters at: #flashTransition ifAbsentPut:[IdentityDictionary new])
		at: srcProject put: self.
