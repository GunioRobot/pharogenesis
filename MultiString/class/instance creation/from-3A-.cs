from: aString 

	| multiString |
	(aString isMemberOf: self)
		ifTrue: [^ aString copy].
	multiString _ self new: aString size.
	1 to: aString size do: [:index | multiString basicAt: index put: (aString basicAt: index)].
	^ multiString
