silentlyMoveInstVarNamed: instVarName from: srcClass to: dstClass after: prevInstVarName
	"Move the instvar from srcClass to dstClass.
	Do not perform any checks."
	| srcVars dstVars dstIndex newClass copyOfSrcClass copyOfDstClass |
	copyOfSrcClass _ srcClass copy.
	copyOfDstClass _ dstClass copy.
	
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
		newClass _ self reshapeClass: dstClass toSuper: dstClass superclass.
		self recompile: false from: dstClass to: newClass mutate: true.
	] ifFalse:[
		(dstClass inheritsFrom: srcClass) ifTrue:[
			newClass _ self reshapeClass: srcClass toSuper: srcClass superclass.
			self recompile: false from: srcClass to: newClass mutate: true.
		] ifFalse:[ "Disjunct hierarchies"
			srcClass == dstClass ifFalse:[
				newClass _ self reshapeClass: dstClass toSuper: dstClass superclass.
				self recompile: false from: dstClass to: newClass mutate: true.
			].
			newClass _ self reshapeClass: srcClass toSuper: srcClass superclass.
			self recompile: false from: srcClass to: newClass mutate: true.
		].
	].
	self doneCompiling: srcClass.
	self doneCompiling: dstClass.
	SystemChangeNotifier uniqueInstance classDefinitionChangedFrom: copyOfSrcClass to: srcClass.
	SystemChangeNotifier uniqueInstance classDefinitionChangedFrom: copyOfDstClass to: dstClass.