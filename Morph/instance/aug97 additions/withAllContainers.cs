withAllContainers
	| aList |
	aList _ OrderedCollection new.
	self eachStepInOwnerChainDo:
		[:m | aList add: m].
	^ aList asArray