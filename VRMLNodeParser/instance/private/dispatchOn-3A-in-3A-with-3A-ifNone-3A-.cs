dispatchOn: key in: table with: arg ifNone: aBlock
	^self perform: (table at: key ifAbsent:[^aBlock value]) with: arg.