testFormatter
	"Smalltalk testFormatter"

	"Reformats the source for every method in the system, and
	then compiles that source and verifies that it generates
	identical code"

	| newCodeString methodNode oldMethod newMethod badOnes n |
	badOnes := OrderedCollection new.
	self forgetDoIts.
	'Formatting all classes...' 
		displayProgressAt: Sensor cursorPoint
		from: 0
		to: CompiledMethod instanceCount
		during: 
			[:bar | 
			n := 0.
			self systemNavigation allBehaviorsDo: 
					[:cls | 
					"Transcript cr; show: cls name."

					cls selectors do: 
							[:selector | 
							(n := n + 1) \\ 100 = 0 ifTrue: [bar value: n].
							newCodeString := cls prettyPrinterClass 
										format: (cls sourceCodeAt: selector)
										in: cls
										notifying: nil.
							methodNode := cls compilerClass new 
										compile: newCodeString
										in: cls
										notifying: nil
										ifFail: [].
							newMethod := methodNode generate: #(0 0 0 0).
							oldMethod := cls compiledMethodAt: selector.
							oldMethod = newMethod 
								ifFalse: 
									[Transcript
										cr;
										show: '***' , cls name , ' ' , selector.
									badOnes add: cls name , ' ' , selector]]]].
	self systemNavigation browseMessageList: badOnes asSortedCollection
		name: 'Formatter Discrepancies'