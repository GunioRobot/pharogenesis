upDownArithOp: delta
	"Change a + into a -.  Also do sounds (change the arg to the beep:)."

	| aList index st |
	st _ submorphs detect: [:mm | mm isKindOf: StringMorph] ifNone: [^ self].
	(self nodeClassIs: SelectorNode) ifTrue:
		[aList _ #(+ - * / // \\ min: max:).
		(index _ aList indexOf: self decompile asString) > 0 ifTrue:
			[self setSelector: (aList atWrap: index + delta) in: st.  ^ true].

		aList _ #(= ~= > >= isDivisibleBy: < <=).
		(index _ aList indexOf: self decompile asString) > 0 ifTrue:
			[self setSelector: (aList atWrap: index + delta) in: st.  ^ true].

		aList _ #(== ~~).
		(index _ aList indexOf: self decompile asString) > 0 ifTrue:
			[self setSelector: (aList atWrap: index + delta) in: st.  ^ true].

		'beep:' = self decompile asString ifTrue:
			["replace sound arg"
			self changeSound: delta.
			self acceptSilently.  ^ true].
		].
	^ false