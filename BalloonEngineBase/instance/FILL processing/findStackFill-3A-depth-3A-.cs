findStackFill: fillIndex depth: depth
	| index |
	index _ 0.
	[index < self stackFillSize and:[
		(self stackFillValue: index) ~= fillIndex or:[
			(self stackFillDepth: index) ~= depth]]]
				whileTrue:[index _ index + self stackFillEntryLength].
	index >= self stackFillSize 
		ifTrue:[^-1]
		ifFalse:[^index].
