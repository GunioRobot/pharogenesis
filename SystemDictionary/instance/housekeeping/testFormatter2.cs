testFormatter2    "Smalltalk testFormatter2"
	"Reformats the source for every method in the system, and then verifies that the order of source tokens is unchanged.  The formatting used will be either classic monochrome or fancy polychrome, depending on the setting of the preference #colorWhenPrettyPrinting."

	 | newCodeString badOnes n oldCodeString oldTokens newTokens |
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
			oldCodeString _ (cls sourceCodeAt: selector) asString.
			newCodeString _ (cls compilerClass new)
				format: oldCodeString
				in: cls notifying: nil decorated: Preferences colorWhenPrettyPrinting.
			oldTokens _ oldCodeString findTokens: Character separators.
			newTokens _ newCodeString findTokens: Character separators.
			oldTokens = newTokens ifFalse:
					[Transcript cr; show: '***' , cls name , ' ' , selector.
					badOnes add: cls name , ' ' , selector]]].
].
	Smalltalk browseMessageList: badOnes asSortedCollection name: 'Formatter Discrepancies'