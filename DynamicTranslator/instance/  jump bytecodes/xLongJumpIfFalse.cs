xLongJumpIfFalse
	"	101011xx		longJumpIfFalse: (xxx*256)+yyyyyyyy
		yyyyyyyy

	=>	LongJumpIfFalse
		(xxx*256)+yyyyyyyy
		nil
		nil"

	"	-20	MacroTempConstLessEq	_	MacroUpLoopTest
		-16	<SmallInteger>
		-12	[ PushConst
		-8	  <SmallInteger>
		-4	  PrimLessEq
		-0	  nil ]"
	self rewrite: -20 from: MacroTempConstLessEq to: MacroUpLoopTest.

	self emitOp: LongJumpIfFalse.
	self emitOffset: ((currentByte bitAnd: 3) * 256) + self nextByte.
	self emitSkip: 2.