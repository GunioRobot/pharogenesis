newSubclassOf: newSuper type: type instanceVariables: instVars from: oldClass unsafe: unsafe
	"Create a new subclass of the given superclass.
	Note: The new class may be meta."
	| newFormat newClass meta |
	"Compute the format of the new class"
	newFormat _ 
		self computeFormat: type 
			instSize: instVars size 
			forSuper: newSuper 
			ccIndex: (oldClass ifNil:[0] ifNotNil:[oldClass indexIfCompact]).
	newFormat == nil ifTrue:[^nil].

	"Check if we really need a new subclass"
	(oldClass ~~ nil and:[
		newSuper == oldClass superclass and:[
			newFormat = oldClass format and:[
				instVars = oldClass instVarNames]]]) 
					ifTrue:[^oldClass].

	unsafe ifFalse:[
		"Make sure we don't redefine any dangerous classes"
		(self tooDangerousClasses includes: oldClass name) ifTrue:[
			self error: oldClass name, ' cannot be changed'.
			^nil].

		"Check if the receiver should not be redefined"
		(oldClass ~~ nil and:[oldClass shouldNotBeRedefined]) ifTrue:[
			self notify: oldClass name asText allBold, 
						' should not be redefined! \Proceed to store over it.' withCRs]].

	oldClass == nil ifTrue:["Requires new metaclass"
		meta _ Metaclass new.
		meta
			superclass: (newSuper ifNil:[Class] ifNotNil:[newSuper class])
			methodDictionary: MethodDictionary new
			format: (newSuper ifNil:[Class format] ifNotNil:[newSuper class format]).
		meta superclass addSubclass: meta. "In case of Class"
		newClass _ meta new.
	] ifFalse:[ newClass _ oldClass shallowCopy ].
	newClass 
		superclass: newSuper
		methodDictionary: MethodDictionary new
		format: newFormat;
		setInstVarNames: instVars;
		organization: (oldClass ifNotNil:[oldClass organization]).
	^newClass