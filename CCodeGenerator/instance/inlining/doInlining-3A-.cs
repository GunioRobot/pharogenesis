doInlining: inlineFlag
	"Inline the bodies of all methods that are suitable for inlining."
	"Modified slightly for the translator, since the first level of inlining for the interpret loop must be performed in order that the instruction implementations can easily discover their addresses."

	| pass progress |
	inlineFlag ifFalse: [
		self inlineDispatchesInMethodNamed: #interpret localizingVars: #().
		^ self].

	self collectInlineList.
	pass _ 0.
	progress _ true.
	[progress] whileTrue: [
		"repeatedly attempt to inline methods until no further progress is made"
		progress _ false.
		('Inlining pass ', (pass _ pass + 1) printString, '...')
			displayProgressAt: Sensor cursorPoint
			from: 0 to: methods size
			during: [:bar |
				methods doWithIndex: [:m :i |
					bar value: i.
					(m tryToInlineMethodsIn: self)
						ifTrue: [progress _ true]]]].

	'Inlining bytecodes'
		displayProgressAt: Sensor cursorPoint
		from: 1 to: 2
		during: [:bar |
			self inlineDispatchesInMethodNamed: #interpret
				localizingVars: #(currentBytecode localIP localSP localHomeContext).
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
