fromSpec: aNodeSpec
	aNodeSpec attributes do:[:attr|
		attr isEvent ifFalse:[attr setValue: attr value in: self]].