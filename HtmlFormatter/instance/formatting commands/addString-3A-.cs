addString: aString
	"adds the text in the given string.  It collapses spaces unless we are in a preformatted region"

	| space compacted lastC i |

	aString isEmpty ifTrue: [ ^self ].

	space _ Character space.


	preformattedLevel > 0 ifTrue: [
		"add all the characters as literals"
		outputStream nextPutAll: aString.

		"update the counters"
		lastC _ aString last.
		(lastC = space or: [ lastC = Character cr ]) ifTrue: [
			"how many of these are there?"
			i _ aString size - 1.
			[ i >= 1 and: [ (aString at: i) = lastC ] ] whileTrue: [ i _ i - 1 ].
			i = 0 ifTrue: [
				"the whole string is the same character!"
				lastC = space ifTrue: [
					precedingSpaces _ precedingSpaces + aString size.
					precedingNewlines _ 0.
					^self ]
				ifFalse: [
					precedingSpaces _ 0.
					precedingNewlines _ precedingNewlines + aString size.
					^self ]. ].
			lastC = space ifTrue: [
				precedingSpaces _ aString size - i.
				precedingNewlines _ 0 ]
			ifFalse: [
				precedingSpaces _ 0.
				precedingNewlines _ aString size - i ] ] ]
	ifFalse: [
		compacted _ aString withSeparatorsCompacted.

		compacted = ' ' ifTrue: [
			"no letters in the string--just white space!"
			(precedingNewlines = 0 and: [precedingSpaces = 0]) ifTrue: [
				precedingSpaces _ 1.
				outputStream nextPut: space. ].
			^self ].

		(compacted first = Character space and: [
			(precedingSpaces > 0) or: [ precedingNewlines > 0] ])
		ifTrue: [ compacted _ compacted copyFrom: 2 to: compacted size ].

		outputStream nextPutAll: compacted.

		"update counters"
		precedingNewlines _ 0.
		compacted last = space 
			ifTrue: [ precedingSpaces _ 1 ]
			ifFalse: [ precedingSpaces _ 0 ]. ]