writeMethod: obj
	| nptrs |
	nptrs _ obj numLiterals + 1.
	self new: obj
		class: obj class
		length: (self sizeInWordsOf: obj)
		trace: [2 to: nptrs do: [:i | self trace: (obj objectAt: i)]]
		write: 
			[self writePointerField: (self methodHeader: obj).
			2 to: nptrs do: [:i | self writePointerField: (obj objectAt: i)].
			nptrs * 4 + 1 to: obj size do: [:i | file nextPut: (obj at: i)].
			file padToNextLongPut: 0]