setGridSize

	| response result |
	response _
		FillInTheBlank
			request: 'New grid size: '
			initialAnswer: grid printString.
	response isEmpty ifTrue: [^ self].
	result _ Compiler evaluate: response.
	gridOn _ true.  "in case it was off -- otherwise this cmd might be upsetting!"
	((result isKindOf: Point) and: [(result > (0@0)) & (result < (37 @ 37))]) ifTrue:
		[^ grid _ result].
	((result isKindOf: SmallInteger) and: [(result > 0) & (result < 37)]) ifTrue:
		[^ grid _ result @ result].
	self inform: 'Must be a Point or an Integer with
coordinates between 1 & 36'	
