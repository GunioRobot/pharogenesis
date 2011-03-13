cleanUp

	| proj |

	mostRecent _ mostRecent reject: [ :each |
		proj _ each fourth first.
		proj isNil or: [proj world isNil]
	].
	self changed.
