forget: aProject

	| newTuple |
	newTuple _ {
		aProject name.
		aProject thumbnail.
		aProject url.
		WeakArray with: aProject.
	}.
	mostRecent _ mostRecent reject: [ :each |
		each fourth first == aProject or: [
			each fourth first isNil & (each first = newTuple first)
		].
	].
	self changed.
	^newTuple