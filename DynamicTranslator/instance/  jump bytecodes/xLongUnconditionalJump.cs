xLongUnconditionalJump
	"	10100xxx		longUnconditionalJump: (xxx-4)*256+yyyyyyyy
		yyyyyyyy

	=>	LongUnconditionalJump
		((xxx-4)*256)+yyyyyyyy
		nil
		nil"

	"	-28	MacroTempConstAddTemp		_	MacroLoopStep
		-24	<SmallInteger>
		-20	[ PushConst
		-16	  <SmallInteger>
		-12	  PrimAdd
		-8	  nil
		-4	  PopStoreTemp
		-0	  <SmallInteger> ]"
	self rewrite: -28 from: MacroTempConstAddTemp to: MacroLoopStep.

	self emitOp: LongUnconditionalJump.
	self emitOffset: (((currentByte bitAnd: 7) - 4) * 256) + self nextByte.
	self emitSkip: 2.