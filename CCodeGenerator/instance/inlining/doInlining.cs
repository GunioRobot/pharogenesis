doInlining
	"Inline the bodies of all methods that are suitable for inlining."
	"Interpreter translate: 'InterpTest.c' doInlining: true"

	| pass progress |
	self collectInlineList.
	"xxx do we need the following?"
	Interpreter primitiveTable do: [ :sel |
		inlineList remove: sel ifAbsent: [].
	].

	pass _ 0.
	progress _ true.
	[progress] whileTrue: [
		"repeatedly attempt to inline methods until no further progress is made"
		progress _ false.
		('Inlining pass ', (pass _ pass + 1) printString, '...')
			displayProgressAt: Sensor cursorPoint
			from: 0 to: methods size
			during: [ :bar |
				methods doWithIndex: [ :m :i |
					bar value: i.
					(m tryToInlineMethodsIn: self)
						ifTrue: [progress _ true]]].
	].
	'Inlining bytecodes'
		displayProgressAt: Sensor cursorPoint
		from: 1 to: 2
		during: [ :bar |
			self inlineDispatchesInMethodNamed: #interpret
				localizingVars: #(currentBytecode localIP localSP).
			bar value: 1.
			self removeMethodsReferingToGlobals: #(currentBytecode localIP localSP)
				except: #interpret.
			bar value: 2.
	].
