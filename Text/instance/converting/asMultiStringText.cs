asMultiStringText

	string class == MultiString ifFalse: [
		^ self class string: (MultiString from: string) runs: self runs copy.
	].
	^ self.
