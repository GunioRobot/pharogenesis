convertAssignmentsToAnsi: aText
	"If the Preference is to show ansiAssignments then answer a copy of  <aText> where each  left arrow assignment is replaced with a ':=' ansi assignment. A parser is used so that each left arrow is only replaced if it occurs within an assigment statement"

	^self replaceStringForRangesWithType: #assignment with: ':=' in: aText