writeHashArrayPermuted: obj useIdentity: useIdentity
	"Elements of a Set's hashed array need to be reordered according to new oops."
	| length perm |
	self new: obj class: obj class length: (length _ self sizeInWordsOf: obj)
		trace:	[1 to: length do: [:i | self trace: (obj basicAt: i)].
				"Now get permutation based on new oops"
				perm _ self permutationFor: obj useIdentity: useIdentity]
		write:	[1 to: length do:
					[:i | self writePointerField: ((perm at: i) == nil
										ifTrue: [nil]
										ifFalse: [obj basicAt: (perm at: i)])]]