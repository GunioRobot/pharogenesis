writeHashArray: obj permutedBy: perm
	"Elements of a Set's hashed array need to be reordered according to perm."
	| length |
	self new: obj class: obj class length: (length _ self sizeInWordsOf: obj)
		trace:	[1 to: length do:
					[:i | self trace: (obj basicAt: i)]]
		write:	[1 to: length do:
					[:i | self writePointerField: ((perm at: i) == nil
										ifTrue: [nil]
										ifFalse: [obj basicAt: (perm at: i)])]]