windowColorFor: aModelClassName
	| classToCheck windowColors |
	(Parameters includesKey: #windowColors) ifFalse:
		[Parameters at: #windowColors put: IdentityDictionary new.
		self installBrightWindowColors].
	classToCheck _ Smalltalk at: aModelClassName.
	windowColors _ Parameters at: #windowColors.
	[windowColors includesKey: classToCheck name]
		whileFalse:
			[classToCheck _ classToCheck superclass].
	^ windowColors at: classToCheck name ifAbsent: [Color white]
	