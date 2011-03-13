wordingForOperator: aString
	| toTest |

	toTest _ aString asString.
	#(	(forward:				'forward by')
		(turn:					'turn by')
		(beep:					'make sound')
		(bounce:				'bounce')
		(stopProgramatically	'stop')
		(wearCostumeOf:		'look like')
		(moveToward:			'move toward')
		(goToRightOf:			'align after')
		(max:					'max')
		(min:					'min')
		(=						'=?'))

	do:
		[:pair | toTest = pair first ifTrue: [^ pair second]].

	^ toTest