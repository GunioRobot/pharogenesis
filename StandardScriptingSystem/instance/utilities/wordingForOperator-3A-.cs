wordingForOperator: aString
	| toTest |

	toTest _ aString asString.
	#(	(beep:					'make sound')
		(bounce:				'bounce')
		(clearTurtleTrails		'clear pen trails')
		(forward:				'forward by')
		(moveToward:			'move toward')
		(goToRightOf:			'align after')
		(isDivisibleBy:			'is divisible by')
		(liftAllPens				'lift all pens')
		(lowerAllPens			'lower all pens')
		(pauseScript:			'pause script')
		(max:					'max')
		(min:					'min')
		(seesColor:				'is over color')
		(makeNewDrawingIn:	'start painting in')
		(startScript:				'start script')
		(stopProgramatically	'stop')
		(stopScript				'stop script')
		(turn:					'turn by')
		(wearCostumeOf:		'look like')
		(=						'=?'))

	do:
		[:pair | toTest = pair first ifTrue: [^ pair second]].

	^ toTest