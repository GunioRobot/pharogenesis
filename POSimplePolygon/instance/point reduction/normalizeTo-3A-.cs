normalizeTo: normLength
	| num unitLength normalized cumulativeLength proportion edgeLength start end |
	num _ self length // normLength.
	num _ num max: 8.
	unitLength _ self length / num.
	normalized _ OrderedCollection new: num.
	normalized add: self vertices first.
	cumulativeLength _ 0.
	1 to: self vertices size do: [:idx|
		start _ self vertices at: idx.
		end _ self vertices atWrap: idx+1.
		edgeLength _ start dist: end.
		cumulativeLength _ cumulativeLength + edgeLength.
		[cumulativeLength >= unitLength]
			whileTrue: 
				[cumulativeLength _ cumulativeLength - unitLength.
				proportion _ cumulativeLength / edgeLength.
				normalized add: (end interpolateTo: start at: proportion)]].
	self vertices: normalized