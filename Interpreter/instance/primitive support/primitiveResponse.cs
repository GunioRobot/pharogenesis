primitiveResponse
	"NB: tpr removed the timer checks here and moved them to the primitiveExternalCall method.
	We make the possibly unwarranted assumption that numbered prims are quick and external prims are slow."

	| delta primIdx nArgs |
	DoBalanceChecks ifTrue:["check stack balance"
		nArgs _ argumentCount.
		delta _ stackPointer - activeContext.
	].
	primIdx _ primitiveIndex.
	successFlag _ true.
	"self dispatchOn: primitiveIndex in: primitiveTable."
	self dispatchFunctionPointerOn: primIdx in: primitiveTable.
	"replace with fetch entry primitiveIndex from table and branch there"
	DoBalanceChecks ifTrue:[
		(self balancedStack: delta afterPrimitive: primIdx withArgs: nArgs) 
			ifFalse:[self printUnbalancedStack: primIdx].
	].
	^ successFlag
