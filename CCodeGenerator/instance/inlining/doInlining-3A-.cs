doInlining: inlineFlag
	"Inline the bodies of all methods that are suitable for inlining."
	"Modified slightly for the core VM translator, since the first level of inlining for the interpret loop must be performed in order that the instruction implementations can easily discover their addresses. Remember to inline the bytecode routines as well"

	inlineFlag ifFalse: [
		self inlineDispatchesInMethodNamed: #interpret localizingVars: #().
		^ self].

	self doBasicInlining: inlineFlag.
	
	'Inlining bytecodes'
		displayProgressAt: Sensor cursorPoint
		from: 1 to: 2
		during: [:bar |
			self inlineDispatchesInMethodNamed: #interpret
				localizingVars: #(currentBytecode localIP localSP localHomeContext localReturnContext localReturnValue).
			bar value: 1.
			self removeMethodsReferingToGlobals: #(
					currentBytecode localIP localSP localHomeContext)
				except: #interpret.
			bar value: 2].

	"make receiver on the next line false to generate code for all methods, even those that are inlined or unused"
	true ifTrue: [
		(methods includesKey: #interpret) ifTrue: [
			"only prune when generating the interpreter itself"
			self pruneUnreachableMethods]].
