initialize
	"Add the style constants gently, beginGently, endGently, and abruptly to the WonderlandConstants dictionary"

	| dict |

	dict _ Smalltalk at: #WonderlandConstants.
	dict at: 'gently' put:
			[:elapsed :duration | WonderlandStyle gentlyAfter: elapsed outOf: duration ].
	dict at: 'beginGently' put:
			[:elapsed :duration | WonderlandStyle beginGentlyAfter: elapsed outOf: duration ].
	dict at: 'endGently' put:
			[:elapsed :duration | WonderlandStyle endGentlyAfter: elapsed outOf: duration ].
	dict at: 'abruptly' put:
			[:elapsed :duration | WonderlandStyle abruptlyAfter: elapsed outOf: duration ].
