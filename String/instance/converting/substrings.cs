substrings
	"Answer an array of the substrings that compose the receiver."
	| result end beginning |

	result _ WriteStream on: (Array new: 10).



	end _ 0.
	"find one substring each time through this loop"
	[ 
		"find the beginning of the next substring"
		beginning _ self indexOfAnyOf: CSNonSeparators startingAt: end+1 ifAbsent: [ nil ].
		beginning ~~ nil ] 
	whileTrue: [
		"find the end"
		end _ self indexOfAnyOf: CSSeparators startingAt: beginning ifAbsent: [ self size + 1 ].
		end _ end - 1.

		result nextPut: (self copyFrom: beginning to: end).

	].


	^result contents