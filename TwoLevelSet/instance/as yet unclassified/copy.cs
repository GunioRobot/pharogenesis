copy

	| answer |

	answer _ self class new initialize.
	self do: [ :each |
		answer add: each
	].
	^answer