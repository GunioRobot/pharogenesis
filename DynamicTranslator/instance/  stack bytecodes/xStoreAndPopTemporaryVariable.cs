xStoreAndPopTemporaryVariable
	"	01101xxx		storeAndPopTemporaryVariable: xxx

	=>	StoreAndPopTemporaryVariable
		xxx"

	"	-20	opPushTemp{Temp{Add,Sub,Mul},ConstAdd}	
		-16	<index>
		-12	[ opMacroConst{Add,Sub.Mul}
		-8	  <SmallInteger>
		-4	  [ opPrim{Add,Sub.Mul}
		-0	    <nil> ] ]			<--- opPointer
		+0	PopStoreTemp		<--- bytePointer"

	(self rewrite: -20 from: MacroTempTempAdd to: MacroTempTempAddTemp) ifFalse:
	"The following two are very rare -- is it really worth it?"
	[(self rewrite: -20 from: MacroTempTempSub to: MacroTempTempSubTemp) ifFalse:
	[(self rewrite: -20 from: MacroTempTempMul to: MacroTempTempMulTemp) ifFalse:
	"This is the first part of the loop step sequence"
	[(self rewrite: -20 from: MacroTempConstAdd to: MacroTempConstAddTemp)]]].

	self emitOp: StoreAndPopTemporaryVariable.
	self emitInteger: (currentByte bitAnd: 7).