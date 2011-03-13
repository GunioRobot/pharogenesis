correctAgainstEnumerator: wordBlock continuedFrom: oldCollection
	"The guts of correction, instead of a wordList, there is a block that should take abnother block and enumerate over some list with it."

	| choices scoreMin results score |
	scoreMin _ self size // 2 min: 3.
	oldCollection isNil
		ifTrue: [ choices _ SortedCollection sortBlock: [ :x :y | x value > y value ] ]
		ifFalse: [ choices _ oldCollection ].
	wordBlock isNil
		ifFalse:
			[ wordBlock value: [ :word |
				(score _ self alike: word) >= scoreMin ifTrue:
					[ choices add: (Association key: word value: score).
						(choices size >= 5) ifTrue: [ scoreMin _ (choices at: 5) value] ] ].
			results _ choices ]
		ifTrue:
			[ results _ OrderedCollection new.
			1 to: (5 min: choices size) do: [ :i | results add: (choices at: i) key ] ].
	^ results