timeStampForMethod: method
	"Answer the authoring time-stamp for the given method, retrieved from the sources or changes file. Answer the empty string if no time stamp is available."

	| position file preamble stamp tokens tokenCount |
	method fileIndex == 0 ifTrue: [^ String new].  "no source pointer for this method"
	position _ method filePosition.
	file _ SourceFiles at: method fileIndex.
	file ifNil: [^ String new].  "sources file not available"
	file _ file readOnlyCopy.
	file position: (0 max: position - 150).  "Skip back to before the preamble"
		[file position < (position - 1)]  "then pick it up from the front"
			whileTrue: [preamble _ file nextChunk].
		stamp _ String new.
		tokens _ (preamble findString: 'methodsFor:' startingAt: 1) > 0
			ifTrue: [Scanner new scanTokens: preamble]
			ifFalse: [Array new  "ie cant be back ref"].
		(((tokenCount _ tokens size) between: 7 and: 8) and: [(tokens at: tokenCount - 5) = #methodsFor:])
			ifTrue:
				[(tokens at: tokenCount - 3) = #stamp:
					ifTrue: ["New format gives change stamp and unified prior pointer"
							stamp _ tokens at: tokenCount - 2]].
		((tokenCount between: 5 and: 6) and: [(tokens at: tokenCount - 3) = #methodsFor:])
			ifTrue:
				[(tokens at: tokenCount  - 1) = #stamp:
					ifTrue: ["New format gives change stamp and unified prior pointer"
						stamp _ tokens at: tokenCount]].
	file close.
	^ stamp