next: anInteger 

	| multiString |
	self isBinary ifTrue: [^ super next: anInteger].
	multiString _ String new: anInteger.
	1 to: anInteger do: [:index |
		| character |
		(character _ self next) ifNotNil: [
			multiString at: index put: character
		] ifNil: [
			multiString _ multiString copyFrom: 1 to: index - 1.
			self doConversion ifFalse: [
				^ multiString
			].
			^ self next: anInteger innerFor: multiString.
		]
	].
	self doConversion ifFalse: [
		^ multiString
	].

	multiString _ self next: anInteger innerFor: multiString.
	(multiString size = anInteger or: [self atEnd]) ifTrue: [ ^ multiString].
	^ multiString, (self next: anInteger - multiString size).
