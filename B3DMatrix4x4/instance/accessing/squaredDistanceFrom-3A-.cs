squaredDistanceFrom: aMatrix
	| sum |
	sum _ 0.0.
	1 to: 4 do:[:i|
		1 to: 4 do:[:j|
			sum _ sum + ((self at: i at: j) - (aMatrix at: i at: j)) squared]].
	^sum