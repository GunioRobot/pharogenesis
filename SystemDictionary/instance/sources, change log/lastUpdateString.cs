lastUpdateString
	"Smalltalk lastUpdateString"
	| aNumber |
	aNumber _ (Smalltalk
		at: #ChangeSorter
		ifAbsent: [^ 'Update # unknown']) highestNumberedChangeSet.
	^ (aNumber notNil and: [aNumber > 0])
		ifTrue: ['latest update: #' , aNumber printString]
		ifFalse: ['No updates present.']