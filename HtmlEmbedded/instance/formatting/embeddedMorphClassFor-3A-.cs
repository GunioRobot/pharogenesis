embeddedMorphClassFor: url
	| lastIndex extension className |
	lastIndex _ url findLast:[:c| c = $.].
	lastIndex = 0 ifTrue:[^nil].
	extension _ url copyFrom: lastIndex+1 to: url size.
	className _ ExtensionList at: extension asLowercase ifAbsent:[^nil].
	^Smalltalk at: className ifAbsent:[nil]
	