arrayEquality: x and: y

	x size = y size ifFalse: [^ false].
	x with: y do: [:e1 :e2 | 
		(self literalEquality: e1 and: e2) ifFalse: [^ false]
	].
	^true.
