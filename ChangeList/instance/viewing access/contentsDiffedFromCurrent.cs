contentsDiffedFromCurrent
	"Answer the contents diffed forward from current (in-memory) method version"

	| aChange aClass |
	listIndex = 0
		ifTrue: [^ ''].
	aChange := changeList at: listIndex.
	^ ((aChange type == #method and: [(aClass := aChange methodClass) notNil]) and: [aClass includesSelector: aChange methodSelector])
		ifTrue:
			 [Utilities methodDiffFor: aChange text class: aClass selector: aChange methodSelector prettyDiffs: self showingPrettyDiffs]
		ifFalse:
			[(changeList at: listIndex) text]