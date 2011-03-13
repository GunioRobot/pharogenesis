testArgumentNames
	self t1 compile: 'zork1: myArgument zork2: mySecondArgument ^true'.
	self t2 compile: 'zork1: myArgument zork2: somethingElse ^false'.
	self assert: ((self t5 sourceCodeAt: #zork1:zork2:) asString 
				beginsWith: 'zork1: t1 zork2: t2').
	self t1 compile: 'zork1: myArgument zork2: mySecondArgument ^true'.
	self t2 compile: 'zork1: somethingElse zork2: myArgument ^false'.
	self assert: ((self t5 sourceCodeAt: #zork1:zork2:) asString 
				beginsWith: 'zork1: t1 zork2: t2')