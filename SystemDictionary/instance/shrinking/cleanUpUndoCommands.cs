cleanUpUndoCommands
	"Smalltalk cleanUpUndoCommands"  "<== print this to get classes involved"

	| classes i p |
	classes _ Bag new.
	'Ferreting out obsolete undo commands'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: Morph withAllSubclasses size
		during:
	[:bar | i _ 0.
	Morph withAllSubclassesDo:
		[:c | bar value: (i _ i+1).
		c allInstancesDo:
			[:m | (p _ m otherProperties) ifNotNil:
				[p keys do:
					[:k | (p at: k) class == Command ifTrue:
						[classes add: c name.
						m removeProperty: k]]]]]].
	^ classes