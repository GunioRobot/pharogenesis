wordingForAssignmentSuffix: aString
	| toTest |

	toTest _ aString asString.
	#(	(':'					'_')
		('Incr:'				'increase by')
		('Decr:'				'decrease by')
		('Mult:'				'multiply by'))
	do:
		[:pair | toTest = pair first ifTrue: [^ pair second]].
	^ toTest

	"ScriptingSystem wordingForAssignmentSuffix: 'Incr:'"