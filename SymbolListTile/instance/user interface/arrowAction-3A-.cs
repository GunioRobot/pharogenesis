arrowAction: delta
	"Do what is appropriate when an arrow on the tile is pressed; delta will be +1 or -1"

	| index |
	owner ifNil: [^ self].

	literal ifNotNil:
		[(index _ choices indexOf: literal) > 0
			ifTrue:
				[self literal: (choices atWrap: index + delta).
				self labelMorph setBalloonText: (ScriptingSystem helpStringForOperator: literal).
				self acceptNewLiteral.
				self labelMorph informTarget]]