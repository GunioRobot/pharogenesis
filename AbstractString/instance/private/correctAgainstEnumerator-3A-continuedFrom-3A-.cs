correctAgainstEnumerator: wordBlock continuedFrom: oldCollection
	"The guts of correction, instead of a wordList, there is a block that should take another block and enumerate over some list with it."

	| choices scoreMin results score maxChoices |
	scoreMin _ self size // 2 min: 3.
	maxChoices _ 10.
	oldCollection isNil
		ifTrue: [ choices _ SortedCollection sortBlock: [ :x :y | x value > y value ] ]
		ifFalse: [ choices _ oldCollection ].
	wordBlock isNil
		ifTrue:
			[ results _ OrderedCollection new.
			1 to: (maxChoices min: choices size) do: [ :i | results add: (choices at: i) key ] ]
		ifFalse:
			[ wordBlock value: [ :word |
				(score _ self alike: word) >= scoreMin ifTrue:
					[ choices add: (Association key: word value: score).
						(choices size >= maxChoices) ifTrue: [ scoreMin _ (choices at: maxChoices) value] ] ].
			results _ choices ].
	^ results