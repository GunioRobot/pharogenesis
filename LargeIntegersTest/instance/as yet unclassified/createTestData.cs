createTestData
	| tmpPos1 tmpPos2 tmpNeg1 tmpNeg2 tmp tmp2 |
	tmpPos1 _ OrderedCollection new.
	tmpPos2 _ OrderedCollection new.
	tmpPos1 add: 0.
	tmpPos2 add: 0.
	tmpPos1 add: 1.
	tmpPos2 add: 1.
	tmpPos1 add: SmallInteger maxVal + 1 * 1000.
	tmpPos2 add: SmallInteger maxVal.
	tmpPos1 add: SmallInteger maxVal.
	tmpPos2 add: 77.
	tmpPos1 add: (2 raisedTo: 7).
	tmpPos2 add: (2 raisedTo: 7).
	tmpPos1 add: (2 raisedTo: 31).
	tmpPos2 add: (2 raisedTo: 31).
	tmpPos1 add: (2 raisedTo: 7).
	tmpPos2 add: (2 raisedTo: 31).
	tmpPos1 add: (2 raisedTo: 31).
	tmpPos2 add: (2 raisedTo: 7).
	tmpPos1 add: (2 raisedTo: 100).
	tmpPos2 add: (2 raisedTo: 100)
			- 1.
	tmpPos1 add: (2 raisedTo: 1000).
	tmpPos2 add: (2 raisedTo: 1000)
			- 1.
	tmpPos1 add: 65535.
	tmpPos2 add: 3.
	tmpPos1 add: 3.
	tmpPos2 add: 65535.
	tmpNeg1 _ tmpPos1 collect: [:e | e negated].
	tmpNeg2 _ tmpPos2 collect: [:e | e negated].
	oc1 _ tmpPos1 , tmpPos1 , tmpNeg1 , tmpNeg1.
	oc2 _ tmpPos2 , tmpNeg2 , tmpNeg2 , tmpPos2.

	ocShift _ (tmpPos1 collect: [:e | e])
				, (tmpPos2 collect: [:e | e]) , (tmpPos1 collect: [:e | e + (2 raisedTo: 32)]) , (tmpPos2 collect: [:e | e + (2 raisedTo: 32)]).
	ocShift2 _ OrderedCollection new.
	0 to: ocShift size - 1 do: [:ix | ocShift2 add: ix].
	ocShift _ ocShift , ocShift.
	ocShift2 addAll: (ocShift2 collect: [:e | e negated]).
	tmp _ OrderedCollection new. tmp2 _ OrderedCollection new.
	ocShift do: [:e | tmp add: e. tmp add: e+1.].
	ocShift2 do: [:e | tmp2 add: e. tmp2 add: e.].
	ocShift _ tmp.
	ocShift2 _ tmp2.
	ocShift _ (ocShift collect: [:e | e negated]), ocShift, ocShift, (ocShift collect: [:e | e negated]).
	ocShift2 _ (ocShift2 collect: [:e | e negated]), (ocShift2 collect: [:e | e negated]), ocShift2 , ocShift2.
