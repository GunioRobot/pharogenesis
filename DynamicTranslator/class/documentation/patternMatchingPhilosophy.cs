patternMatchingPhilosophy
"
There are two possible approaches to matching patterns of bytecodes.  The obvious way is to look forward in the CompiledMethod being translated for particular bytecode patterns, and choose an opcode to emit for the current bytecode based on the bytecodes that follow.  A less obvious way is to look backwards at the opcodes that were translated for previous bytecodes, and back-patch some previous opcode during the translation of the last bytecode in the 'matched' sequence.  We choose the latter approach (with a few pragmatic hybrids -- e.g. xPrimBlockCopy) for several reasons:

	- it reduces considerably the number of comparisons that have to be performed;

	- it eliminates the need to detect sets of equivalent bytecodes
		(e.g: push{LiteralConstant,Const{MinusOne,Zero,One,Two}} are all translated as 'PushConstant', so
		 checking the opcode rather than the bytecode reduces the number of cases that must be detected
		 from five to one);

	- pattern matching can be done incrementally by checking for previous 'sub-optimisations'
		(e.g:	pushTemp pushConst add popStoreTemp
			is detected by looking for:
				pushTemp macroPushConstAdd <ignored> popStoreTemp).
	  This has the pleasant side-effect that things like 'pushTemp pushTemp' are encoded as
	  'PushTempTemp' for the benefit of faster matching, but will also work as perfectly good
	  macros in their own right (making for a faster VM) should the expected pattern fail to
	  be matched later on.

This approach has other, subtler benefits.  For example, consider a situation where three pushTemp bytecodes appear contiguously, with the second being a branch destination:

				original code		(sub)optimisations
				---------------		---------------------
			0:	pushTemp A
			1:	jumpTo then
	else:	2:	pushTemp B			_ pushTempTemp B,C (implicit jumpTo: 4)
	then:	3:	pushTemp C
			4:	. . .

In this case we get optimal behaviour regardless of whether the code is entered from the top or from the branch destination.  (For the incredulous, the above pattern will occur, exactly as shown, in: '(cond ifTrue: [tempA] ifFalse: [tempB]) foo: tempC'.)

Finally, if the translator ever breaks away from the current linear proportionality between vPC and tPC, the above matching mechanism will cope with the single- and double-extended forms of various bytecodes without any changes whatsoever.
"
	^self error: 'documentation only'