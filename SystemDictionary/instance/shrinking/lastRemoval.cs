lastRemoval			"Smalltalk lastRemoval"

	 | oldDicts newDicts |

	"Some explicit removals - add unwanted methods keeping other methods."
	#(abandonSources printSpaceAnalysis)
		do: [:each | self class removeSelector: each].

	"Get rid of all unsent methods."
	[self removeAllUnSentMessages > 0] whileTrue.

	"Shrink method dictionaries."
	Smalltalk garbageCollect.
	oldDicts _ MethodDictionary allInstances.
	newDicts _ Array new: oldDicts size.
	oldDicts withIndexDo: [:d :index | 
		newDicts at: index put: d rehashWithoutBecome.
	].
	oldDicts elementsExchangeIdentityWith: newDicts.
	oldDicts _ newDicts _ nil.

	Smalltalk allClassesDo: [:c | c zapOrganization].
	SystemOrganization _ nil.

	Smalltalk changes initialize