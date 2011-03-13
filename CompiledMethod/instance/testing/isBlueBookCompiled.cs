isBlueBookCompiled
	"Answer whether the receiver was compiled using the closure compiler.
	 This is used to help DebuggerMethodMap choose which mechanisms to
	 use to inspect activations of the receiver.
	 This method answers false negatives in that it only identifies methods
	 that create old BlockClosures or use the new BlockClosure bytecodes.
	 It cannot tell if a method which uses neither the old nor the new block
	 bytecodes is compiled with the blue-book compiler or the new compiler.
	 But since methods that don't create blocks have essentially the same
	 code when compiled with either compiler this makes little difference."

	^((InstructionStream on: self) scanFor:
		[:instr |
		(instr >= 138 and: [instr <= 143]) ifTrue: [^false].
		instr = 200])
	   or: [(self hasLiteral: #blockCopy:)
		   and: [self messages includes: #blockCopy:]]