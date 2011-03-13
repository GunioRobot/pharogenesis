supportTestSourceRangeAccessForInjectInto: method source: source selectionSequence: selections
	"Test debugger source range selection for inject:into:"
	| evaluationCount sourceMap debugTokenSequence debugCount |
	DebuggerMethodMap voidMapCache.
	evaluationCount := 0.
	sourceMap := method debuggerMap abstractSourceMap.
	debugTokenSequence := selections collect: [:string| Scanner new scanTokens: string].
	debugCount := 0.
	thisContext
		runSimulated: [(1 to: 2)
						withArgs:
							{	0.
								[:sum :each|
								 evaluationCount := evaluationCount + 1.
								 sum + each]}
						executeMethod: method]
		contextAtEachStep:
			[:ctxt| | range debugTokens |
			(ctxt method == method
			and: ["Exclude the send of #blockCopy: or #closureCopy:copiedValues: and braceWith:with:
				    to create the block, and the #new: and #at:'s for the indirect temp vector.
				   This for compilation without closure bytecodes. (Note that at:put:'s correspond to stores)"
				(ctxt willSend
					and: [(#(closureCopy:copiedValues: blockCopy: new: at: braceWith:with:) includes: ctxt selectorToSendOrSelf) not])
				"Exclude the store of the argument into the home context (for BlueBook blocks)
				 and the store of an indirection vector into an initial temp"
				or: [(ctxt willStore
					and: [(ctxt isBlock and: [ctxt pc = ctxt startpc]) not
					and: [(ctxt isBlock not
						and: [(method usesClosureBytecodes and: [ctxt abstractPC = 2])]) not]])
				or: [ctxt willReturn]]]) ifTrue:
				[debugTokens := debugTokenSequence at: (debugCount := debugCount + 1) ifAbsent: [#(bogusToken)].
				 self assert: (sourceMap includesKey: ctxt abstractPC).
				 range := sourceMap at: ctxt abstractPC ifAbsent: [(1 to: 0)].
				 self assert: (Scanner new scanTokens: (source copyFrom: range first to: range last)) = debugTokens]].
	self assert: evaluationCount = 2