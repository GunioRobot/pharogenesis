conflictMethod
	| templateMethod argumentNames binary numberOfArguments |
	self isConflict ifFalse: [^nil].
	argumentNames _ self getArgumentNames.
	binary _ self isBinarySelector.
	numberOfArguments _ binary
		ifTrue: [1]
		ifFalse: [argumentNames size + 2].
	templateMethod _ self conflictMethodForArguments: numberOfArguments ifAbsentPut: [
		self
			generateTemplateMethodWithMarker: CompiledMethod conflictMarker
			forArgs: argumentNames size
			binary: binary].
	^templateMethod copyWithTempNames: argumentNames
	
	
 