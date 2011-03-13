cleanUpUndoCommands
	"Smalltalk cleanUpUndoCommands"  "<== print this to get classes involved"

	| classes i p |
	classes := Bag new.
	'Ferreting out obsolete undo commands'
		displayProgressAt: Sensor cursorPoint
		from: 0 to: Morph withAllSubclasses size
		during:
	[:bar | i := 0.
	Morph withAllSubclassesDo:
		[:c | bar value: (i := i+1).
		c allInstancesDo:
			[:m | (p := m otherProperties) ifNotNil:
				[p keys do:
					[:k | (p at: k) class == Command ifTrue:
						[classes add: c name.
						m removeProperty: k]]]]]].
	^ classes