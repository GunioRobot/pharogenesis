testFormatter    "Smalltalk testFormatter"
	"Reformats the source for every method in the system, and then compiles that source and verifies that it generates identical code.   The formatting used will be either classic monochrome or fancy polychrome, depending on the setting of the preference #colorWhenPrettyPrinting."

	 | newCodeString methodNode oldMethod newMethod badOnes n |
	badOnes _ OrderedCollection new.
	Smalltalk forgetDoIts.
'Formatting all classes...'
displayProgressAt: Sensor cursorPoint
from: 0 to: CompiledMethod instanceCount
during: [:bar | n _ 0.
	Smalltalk allBehaviorsDo:
		[:cls | 
		"Transcript cr; show: cls name."
		cls selectors do:
			[:selector | (n _ n+1) \\ 100 = 0 ifTrue: [bar value: n].
			newCodeString _ (cls compilerClass new)
				format: (cls sourceCodeAt: selector)
				in: cls notifying: nil decorated: Preferences colorWhenPrettyPrinting.
			methodNode _ cls compilerClass new
						compile: newCodeString
						in: cls notifying: nil ifFail: [].
			newMethod _ methodNode generate: #(0 0 0 0).
			oldMethod _ cls compiledMethodAt: selector.
			oldMethod = newMethod ifFalse: [Transcript cr; show: '***' , cls name , ' ' , selector.
											badOnes add: cls name , ' ' , selector]]].
].
	Smalltalk browseMessageList: badOnes asSortedCollection name: 'Formatter Discrepancies'