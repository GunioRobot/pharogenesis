doInlining: inlineFlag
	"Inline the bodies of all methods that are suitable for inlining."
	"Modified slightly for the translator, since the first level of inlining for the interpret
	loop must be performed in order that the instruction implementations can easily
	discover their addresses."

	"Interpreter translate: 'InterpTest.c' doInlining: true"

	| pass progress |

	inlineFlag ifFalse: [
		^self inlineDispatchesInMethodNamed: #interpret localizingVars: #().
	].

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
		from: 1 to: 3
		during: [ :bar |
			self inlineDispatchesInMethodNamed: #interpret
				localizingVars: #(currentBytecode localIP localSP localCP localTP).
			bar value: 1.
"xxx
			(methods includesKey: #translateNewMethod) ifTrue:
				[self inlineDispatchesInMethodNamed: #translateNewMethod
					localizingVars: #(currentByte bytePointer opPointer).
				self removeMethodsReferingToGlobals: #(currentByte bytePointer opPointer)
					except: #translateNewMethod.
				].
xxx"
			bar value: 2.
			self removeMethodsReferingToGlobals: #(currentBytecode localIP localSP localCP localTP)
				except: #interpret.
			bar value: 3.
	].
