commonBytecodeSequences
"
pushTrue shortJumpIfTrue						-> extendedJump		(unimplemented)
pushTrue shortJumpIfFalse						-> extendedNoop		(unimplemented)
pushFalse shortJumpIfTrue						-> extendedNop		(unimplemented)
pushFalse shortJumpIfFalse						-> extendedJump		(unimplemented)

pushLit returnTop								-> returnLit

pop dup											-> popDup			(implemented)

thisCtx pushLit blockCopy longJump				-> pushBlock		(implemented)

pushLit add										-> pushLitAdd		(implemented)
pushLit sub										-> pushLitSub		(implemented)
pushLit mul										-> pushLitMul		(implemented)
pushLit bitShift									-> pushLitBitShift	(implemented)
pushLit bitOr									-> pushLitBitAnd		(implemented)
pushLit bitAnd									-> pushLitBitOr		(implemented)

{cond} jumpTrue									-> {cond}JumpTrue
{cond} jumpFalse									-> {cond}JumpFalse

pushTemp pushTemp add popStoreTemp			-> addTemps			(implemented)

pushTemp popStoreInst							-> moveTempInst		(implemented)

pushTemp pushConst <= jumpFalse				-> loopTestUp
pushTemp pushConst >= jumpFalse				-> loopTestDown
pushTemp pushConst + popStoreTemp longJump	-> loopStep

specialise return bytecodes within blocks:
	returnXyz									-> localReturnXyz
	[... returnXyz ...]							-> nonLocalReturnXyz
"
	^self error: 'documentation only'