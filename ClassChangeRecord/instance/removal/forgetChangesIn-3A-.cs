forgetChangesIn: otherRecord
	"See forgetAllChangesFoundIn:.  Used in culling changeSets."

	| cls otherMethodChanges selector actionToSubtract |
	(cls _ self realClass) == nil ifTrue: [^ self].  "We can do better now, though..."
	otherMethodChanges _ otherRecord methodChangeTypes.
	otherMethodChanges associationsDo:
		[:assoc | selector _ assoc key. actionToSubtract _ assoc value.
		(cls includesSelector: selector)
			ifTrue: [(#(add change) includes: actionToSubtract)
					ifTrue: [methodChanges removeKey: selector ifAbsent: []]]
			ifFalse: [(#(remove addedThenRemoved) includes: actionToSubtract)
					ifTrue: [methodChanges removeKey: selector ifAbsent: []]]].
	changeTypes isEmpty ifFalse:
		[changeTypes removeAllFoundIn: otherRecord allChangeTypes.
		(changeTypes includes: #rename) ifFalse:
			[changeTypes removeAllSuchThat: [:x | x beginsWith: 'oldName: ']]]