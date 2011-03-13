backgroundWorldDisplay

	| f |

	self flag: #bob.		"really need a better way to do this"

			"World displayWorldSafely."

	"ugliness to try to track down a possible error"


	[World displayWorld] ifError: [ :a :b |
		stageCompleted _ 999.
		f _ FileDirectory default fileNamed: 'bob.errors'.
		f nextPutAll: a printString,'  ',b printString; cr; cr.
		f nextPutAll: 'worlds equal ',(formerWorld == World) printString; cr; cr.
		f nextPutAll: thisContext longStack; cr; cr.
		f nextPutAll: formerProcess suspendedContext longStack; cr; cr.
		f close. 1 beep.
	].
