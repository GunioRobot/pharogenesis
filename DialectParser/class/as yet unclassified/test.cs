test    "DialectParser test"

"PrettyPrints the source for every method in the system in the alternative syntax, and then compiles that source and verifies that it generates identical code.  No changes are actually made to the system.  At the time of this writing, only two methods caused complaints (reported in Transcript and displayed in browse window after running):

	BalloonEngineSimulation circleCosTable and
	BalloonEngineSimulation circleSinTable.

These are not errors, but merely a case of Floats embedded in literal arrays, and thus not specially checked for roundoff errors.

Note that if an error or interruption occurs during execution of this method, the alternativeSyntax preference will be left on.

NOTE:  Some methods may not compare properly until the system has been recompiled once.  Do this by executing...
		Smalltalk recompileAllFrom: 'AARDVAARK'.
"

	 | newCodeString methodNode oldMethod newMethod badOnes n heading |
	Preferences enable: #printAlternateSyntax.
	badOnes _ OrderedCollection new.
	Transcript clear.
	Smalltalk forgetDoIts.
'Formatting and recompiling all classes...'
displayProgressAt: Sensor cursorPoint
from: 0 to: CompiledMethod instanceCount
during: [:bar | n _ 0.
	Smalltalk allClassesDo:  "{MethodNode} do:"  "<- to check one class"
		[:nonMeta |  "Transcript cr; show: nonMeta name."
		{nonMeta. nonMeta class} do:
		[:cls |
		cls selectors do:
			[:selector | (n _ n+1) \\ 100 = 0 ifTrue: [bar value: n].
			newCodeString _ (cls compilerClass new)
				format: (cls sourceCodeAt: selector)
				in: cls notifying: nil decorated: Preferences colorWhenPrettyPrinting.
			heading _ cls organization categoryOfElement: selector.
			methodNode _ cls compilerClass new
						compile: newCodeString
						in: cls notifying: (SyntaxError new category: heading)
						ifFail: [].
			newMethod _ methodNode generate: #(0 0 0 0).
			oldMethod _ cls compiledMethodAt: selector.
			"Transcript cr; show: cls name , ' ' , selector."
			oldMethod = newMethod ifFalse:
				[Transcript cr; show: '***' , cls name , ' ' , selector.
				oldMethod size = newMethod size ifFalse:
					[Transcript show: ' difft size'].
				oldMethod header = newMethod header ifFalse:
					[Transcript show: ' difft header'].
				oldMethod literals = newMethod literals ifFalse:
					[Transcript show: ' difft literals'].
				Transcript endEntry.
				badOnes add: cls name , ' ' , selector]]]].
].
	self systemNavigation browseMessageList: badOnes asSortedCollection name: 'Formatter Discrepancies'.
	Preferences disable: #printAlternateSyntax.
