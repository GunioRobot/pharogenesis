writeMethodDictionary: obj
	"Elements of a Set need to be reordered according to new oops."
	| perm |
	self new: obj class: obj class length: (self sizeInWordsOf: obj)
		trace:	["First need to map the indexable fields (selectors)"
				1 to: obj basicSize do: [:i | self trace: (obj basicAt: i)].
				"Now get permutation based on new oops"
				perm _ self permutationFor: obj useIdentity: true.
				"Map named inst vars *assuming* 2nd is the hash array"
				1 to: obj class instSize do:
					[:i | i=2 ifTrue: ["Permute the hash array and note its permutation"
									self writeHashArray: (obj instVarAt: i) permutedBy: perm]
							ifFalse: ["Other fields get traced normally"
									self trace: (obj instVarAt: i)]]]
		write:	[1 to: obj class instSize do:
					[:i | self writePointerField: (obj instVarAt: i)].
				1 to: obj basicSize do:
					[:i | self writePointerField: ((perm at: i) == nil
											ifTrue: [nil]
											ifFalse: [obj basicAt: (perm at: i)])]]