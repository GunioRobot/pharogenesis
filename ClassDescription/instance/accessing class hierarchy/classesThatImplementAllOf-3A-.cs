classesThatImplementAllOf: selectorSet
	"Return an array of any classes that implement all the messages in selectorSet."

	| found remaining |
	found _ OrderedCollection new.
	selectorSet do:
		[:sel | (self methodDict includesKey: sel) ifTrue: [found add: sel]].
	found isEmpty
		ifTrue: [^ self subclasses inject: Array new
						into: [:subsThatDo :sub |
							subsThatDo , (sub classesThatImplementAllOf: selectorSet)]]
		ifFalse: [remaining _ selectorSet copyWithoutAll: found.
				remaining isEmpty ifTrue: [^ Array with: self].
				^ self subclasses inject: Array new
						into: [:subsThatDo :sub |
							subsThatDo , (sub classesThatImplementAllOf: remaining)]]