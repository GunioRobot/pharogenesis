writeBehavior: obj
	| length |
	self new: obj
		class: obj class
		length: (length _ self sizeInWordsOf: obj)
		trace: [1 to: length do: [:i | self trace: (obj instVarAt: i)]]
		write: [1 to: 2 do: [:i | self writePointerField: (obj instVarAt: i)].
			self writePointerField: (self formatOfCls: obj).
			4 to: length do: [:i | self writePointerField: (obj instVarAt: i)]]