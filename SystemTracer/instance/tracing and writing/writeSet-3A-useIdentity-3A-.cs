writeSet: obj useIdentity: useIdentity
	"Elements of a Set need to be reordered according to new oops."
	| |
	self basicSize > 0 ifTrue: [self halt. "Not clear how to permute this kind of set"].
	self new: obj class: obj class length: (self sizeInWordsOf: obj)
		trace: 
			["Map named inst vars *assuming* 2nd is the hash array"
			1 to: obj class instSize do:
				[:i | i=2 ifTrue: ["Permute the hash array and note its permutation"
								self writeHashArrayPermuted: (obj instVarAt: i)
											useIdentity: useIdentity]
						ifFalse: ["Other fields get traced normally"
								self trace: (obj instVarAt: i)]]]
		write: 
			[1 to: obj class instSize do:
				[:i | self writePointerField: (obj instVarAt: i)]]