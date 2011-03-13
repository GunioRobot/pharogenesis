checkDecompileMethod: oldMethod
	
	| cls selector oldMethodNode methodNode newMethod oldCodeString newCodeString |
	cls := oldMethod methodClass.
	selector := oldMethod selector.
	oldMethodNode := cls decompilerClass new
						decompile: selector
						in: cls
						method: oldMethod.
	[oldMethodNode properties includesKey: #warning] whileTrue:
		[oldMethodNode properties removeKey: #warning].
	oldCodeString := oldMethodNode decompileString.
	methodNode := [cls compilerClass new
						compile: oldCodeString
						in: cls
						notifying: nil
						ifFail: []]
						on: SyntaxErrorNotification
						do: [:ex|
							ex errorMessage = 'Cannot store into' ifTrue:
								[ex return: #badStore].
							ex pass].
	"Ignore cannot store into block arg errors; they're not our issue."
	methodNode ~~ #badStore ifTrue:
		[newMethod := methodNode generate: #(0 0 0 0).
		 newCodeString := (cls decompilerClass new
							decompile: selector
							in: cls
							method: newMethod) decompileString.
		 "(StringHolder new textContents:
			(TextDiffBuilder buildDisplayPatchFrom: oldCodeString to: newCodeString))
				openLabel: 'Decompilation Differences for ', cls name,'>>',selector"
		 "(StringHolder new textContents:
			(TextDiffBuilder buildDisplayPatchFrom: oldMethod abstractSymbolic to: newMethod abstractSymbolic))
				openLabel: 'Bytecode Differences for ', cls name,'>>',selector"
		 self assert: oldCodeString = newCodeString
			description: cls name asString, ' ', selector asString
			resumable: true]