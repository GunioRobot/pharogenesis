classNameAt: index
	| ccIndex |
	ccIndex _ self compactIndexAt: index.
	ccIndex = 0 ifFalse:[^(Smalltalk compactClassesArray at: ccIndex) name].
	ccIndex _ segment at: index-1.
	(ccIndex bitAnd: 16r80000000) = 0 ifTrue:[
		"within segment; likely a user object"
		^#UserObject].
	ccIndex _ (ccIndex bitAnd: 16r7FFFFFFF) bitShift: -2.
	^(outPointers at: ccIndex) name