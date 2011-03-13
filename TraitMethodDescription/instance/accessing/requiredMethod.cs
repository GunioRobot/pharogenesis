requiredMethod
	| templateMethod argumentNames numberOfArguments binary |
	self isRequired ifFalse: [^nil].
	self size = 1 ifTrue: [^self locatedMethods anyOne method].
	
	argumentNames _ self getArgumentNames.
	binary _ self isBinarySelector.
	numberOfArguments _ binary
		ifTrue: [1]
		ifFalse: [argumentNames size + 2].
	templateMethod _ self requiredMethodForArguments: numberOfArguments ifAbsentPut: [
		self
			generateTemplateMethodWithMarker: CompiledMethod implicitRequirementMarker
			forArgs: argumentNames size
			binary: binary].
	^templateMethod copyWithTempNames: argumentNames
	
	
 