currentDiffedFromContents
	| aChange aClass |
	listIndex = 0
		ifTrue: [^ ''].
	aChange _ changeList at: listIndex.
	^ ((aChange type == #method
				and: [(aClass _ aChange methodClass) notNil])
			and: [aClass includesSelector: aChange methodSelector])
		ifTrue: [TextDiffBuilder
				buildDisplayPatchFrom: aChange text
				to: (aClass sourceCodeAt: aChange methodSelector)
				inClass: aClass]
		ifFalse: [(changeList at: listIndex) text]