upDownAssignment: delta
	"Rotate between increaseBy:  decreaseBy:   _  multiplyBy:"

	| st now want instVar |
	st _ submorphs detect: [:mm | mm isKindOf: StringMorph] ifNone: [^ self].
	(self nodeClassIs: SelectorNode) ifTrue:
		["kinds of assignment"
		((now _ self decompile asString) beginsWith: 'set') ifTrue:
			["a setX: 3"
			want _ 1+delta.  instVar _ (now allButFirst: 3) allButLast].
		(now endsWith: 'IncreaseBy:') ifTrue:
			["a xIncreaseBy: 3 a setX: (a getX +3)."
			want _ 2+delta.  instVar _ now allButLast: 11].
		(now endsWith: 'DecreaseBy:') ifTrue:
			["a xDecreaseBy: 3 a setX: (a getX -3)."
			want _ 3+delta.  instVar _ now allButLast: 11].
		(now endsWith: 'MultiplyBy:') ifTrue:
			["a xMultiplyBy: 3 a setX: (a getX *3)."
			want _ 4+delta.  instVar _ now allButLast: 11].
		want ifNil: [^ false].
		instVar _ instVar asLowercase.
		want _ #(1 2 3 4) atWrap: want.
		want = 1 ifTrue:
			["setter method is present"
			self setSelector: ('set', instVar capitalized, ':') in: st.  ^ true].
		want = 2 ifTrue:
			["notUnderstood will create the method if needed"
			self setSelector: instVar, 'IncreaseBy:' in: st.  ^ true].
		want = 3 ifTrue:
			["notUnderstood will create the method if needed"
			self setSelector: instVar, 'DecreaseBy:' in: st.  ^ true].
		want = 4 ifTrue:
			["notUnderstood will create the method if needed"
			self setSelector: instVar, 'MultiplyBy:' in: st.  ^ true].
		].
	^ false
