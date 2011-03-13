testFormatter2
	"Smalltalk testFormatter2"

	"Reformats the source for every method in the system, and
	then verifies that the order of source tokens is unchanged."

	| newCodeString badOnes n oldCodeString oldTokens newTokens |
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
							oldCodeString := (cls sourceCodeAt: selector) asString.
							newCodeString := cls prettyPrinterClass 
										format: oldCodeString
										in: cls
										notifying: nil.
							oldTokens := oldCodeString findTokens: Character separators.
							newTokens := newCodeString findTokens: Character separators.
							oldTokens = newTokens 
								ifFalse: 
									[Transcript
										cr;
										show: '***' , cls name , ' ' , selector.
									badOnes add: cls name , ' ' , selector]]]].
	self systemNavigation browseMessageList: badOnes asSortedCollection
		name: 'Formatter Discrepancies'