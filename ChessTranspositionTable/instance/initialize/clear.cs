clear
	"Set the following to true for printing information about the fill rate and number of collisions. The transposition table should have *plenty* of free space (it should rarely exceed 30% fill rate) and *very* few collisions (those require us to evaluate positions repeatedly that we've evaluated before -- bad idea!)"

	| entry |
	false 
		ifTrue: 
			[used position > 0 
				ifTrue: 
					['entries used:	' , used position printString , ' (' 
						, (used position * 100 // array size) printString , '%)	' 
						displayAt: 0 @ 0].
			collisions > 0 
				ifTrue: 
					['collisions:		' , collisions printString , ' (' 
						, (collisions * 100 // array size) printString , '%)	' 
						displayAt: 0 @ 15]].
	used position: 0.
	[(entry := used next) isNil] whileFalse: [entry clear].
	used resetToStart.
	collisions := 0