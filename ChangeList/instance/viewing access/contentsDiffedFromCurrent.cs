contentsDiffedFromCurrent
	| aChange aClass |
	listIndex = 0
		ifTrue: [^ ''].
	aChange _ changeList at: listIndex.
	^ ((aChange type == #method and: [(aClass _ aChange methodClass) notNil]) and: [aClass includesSelector: aChange methodSelector])
		ifTrue:
			 [Utilities methodDiffFor: aChange text class: aClass selector: aChange methodSelector]
		ifFalse:
			[(changeList at: listIndex) text]