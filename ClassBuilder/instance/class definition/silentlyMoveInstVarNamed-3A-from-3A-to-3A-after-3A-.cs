silentlyMoveInstVarNamed: instVarName from: srcClass to: dstClass after: prevInstVarName
	"Move the instvar from srcClass to dstClass.
	Do not perform any checks."
	| srcVars dstVars dstIndex |
	srcVars _ srcClass instVarNames copyWithout: instVarName.
	srcClass == dstClass
		ifTrue:[dstVars _ srcVars]
		ifFalse:[dstVars _ dstClass instVarNames].
	dstIndex _ dstVars indexOf: prevInstVarName.
	dstVars _ (dstVars copyFrom: 1 to: dstIndex),
				(Array with: instVarName),
				(dstVars copyFrom: dstIndex+1 to: dstVars size).
	instVarMap at: srcClass name put: srcVars.
	instVarMap at: dstClass name put: dstVars.
	(srcClass inheritsFrom: dstClass) ifTrue:[
		self recompile: false from: dstClass to: dstClass mutate: true.
	] ifFalse:[
		(dstClass inheritsFrom: srcClass) ifTrue:[
			self recompile: false from: srcClass to: srcClass mutate: true.
		] ifFalse:[ "Disjunct hierarchies"
			srcClass == dstClass ifFalse:[
				self recompile: false from: dstClass to: dstClass mutate: true.
			].
			self recompile: false from: srcClass to: srcClass mutate: true.
		].
	].
	self doneCompiling: srcClass.
	self doneCompiling: dstClass.