next: anInteger 

	| multiString |
	"self halt."
	self isBinary ifTrue: [^ (super next: anInteger) asByteArray].
	multiString _ MultiString new: anInteger.
	1 to: anInteger do: [:index |
		| character |
		(character _ self next) ifNotNil: [
			multiString at: index put: character
		] ifNil: [
			multiString _ multiString copyFrom: 1 to: index - 1.
			^ multiString
		]
	].
	^ multiString.
