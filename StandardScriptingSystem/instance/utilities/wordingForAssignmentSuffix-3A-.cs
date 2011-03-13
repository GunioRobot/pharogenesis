wordingForAssignmentSuffix: aString
	| toTest |

	toTest _ aString asString.
	#(	(':'					'_')
		('Incr:'				'<+')
		('Decr:'				'<-')
		('Mult:'				'<*'))
	do:
		[:pair | toTest = pair first ifTrue: [^ pair second]].
	^ toTest

	"ScriptingSystem wordingForAssignmentSuffix: 'Incr:'"