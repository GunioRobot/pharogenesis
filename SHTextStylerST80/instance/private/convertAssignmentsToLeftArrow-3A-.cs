convertAssignmentsToLeftArrow: aText
	"If the Preference is to show leftArrowAssignments then answer a copy of  <aText> where each ansi assignment (:=) is replaced with a left arrow. A parser is used so that each ':=' is only replaced if it actually occurs within an assigment statement"

	^self replaceStringForRangesWithType: #ansiAssignment with: '_' in: aText