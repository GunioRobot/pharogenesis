formOf: char

	| f assoc code |
	char charCode > 255
		ifTrue: [^ self fallbackFont formOf: char].

	code := char charCode.
	assoc := self cache at: (code + 1).
	assoc ifNotNil: [
		(assoc key = foregroundColor) ifTrue: [
			^ assoc value.
		].
	].

	f := self computeForm: code.
	self at: code put: f.
	^ f.
