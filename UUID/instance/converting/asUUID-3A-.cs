asUUID: aString
	| stream token byte |
	stream _ ReadStream on: (aString copyReplaceAll: '-' with: '') asUppercase.
	1 to: stream size/2 do: [:i | 
		token _ stream next: 2.
		byte _ Integer readFrom: (ReadStream on: token ) base: 16.
		self at: i put: byte].
	^self
