processFixedBlock
	litTable _ FixedLitTable.
	distTable _ FixedDistTable.
	state _ state bitOr: BlockProceedBit.
	self proceedFixedBlock.