transitionFrom: srcProjectName to: dstProjectName
	"Return the transition between the two projects"
	| srcProject dstProject |
	srcProject _ (Project named: srcProjectName) ifNil: [Project current].
	dstProject _ (Project named: dstProjectName) ifNil: [Project current].
	^dstProject projectParameters at: #flashTransition ifPresent:[:dict|
		dict at: srcProject ifAbsent:[nil]].
