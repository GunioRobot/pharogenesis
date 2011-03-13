lastRemoval
	"Smalltalk lastRemoval"
	"Some explicit removals - add unwanted methods keeping
	other methods."
	| oldDicts newDicts |
	#(#abandonSources )
		do: [:each | self class removeSelector: each].
	"Get rid of all unsent methods."
	[self removeAllUnsentMessages > 0] whileTrue.
	"Shrink method dictionaries."
	self garbageCollect.
	oldDicts := MethodDictionary allInstances.
	newDicts := Array new: oldDicts size.
	oldDicts
		withIndexDo: [:d :index | newDicts at: index put: d rehashWithoutBecome].
	oldDicts elementsExchangeIdentityWith: newDicts.
	oldDicts := newDicts := nil.
	self
		allClassesDo: [:c | c zapOrganization].
	SystemOrganization := nil.
	ChangeSet current initialize