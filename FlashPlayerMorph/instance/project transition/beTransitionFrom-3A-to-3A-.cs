beTransitionFrom: srcProjectName to: dstProjectName
	"Make the receiver the animation between the two projects"
	| srcProject dstProject |
	srcProject _ (Project named: srcProjectName) ifNil: [Project current].
	dstProject _ (Project named: dstProjectName) ifNil: [Project current].
	(dstProject projectParameters at: #flashTransition ifAbsentPut:[IdentityDictionary new])
		at: srcProject put: self.
