xPrimBlockCopy

	"	-12	opPushActiveContext
		-8	nil
		-4	opPushConstant
		-0	<SmallInteger>	<-- opPointer
		+0	BlockCopy		<-- bytePointer
		+1	LongJump
		+2	<offset>

	Note that we fail to cope with blocks for which the opPushConstant is generated
	from an extendedPush.  Ho hum."

	UseMacroPushBlock ifTrue: [
		((self wasPushInteger: -4) and: [(self wasPushActiveContext: -12) and: [(self isLongJump: 1)]])
			ifTrue:
				[self rewrite: -12 to: MacroPushBlock.
				 "record the fact that we're in a block, for special treatment of certain bytecodes."
				 blockEnd _ bytePointer + 2	+ (((currentByte bitAnd: 7) - 4) * 256)
											+ (self byteAt: bytePointer + 1).
		]
	].

	self emitOp: PrimBlockCopy.
	self emitSkip: 1.