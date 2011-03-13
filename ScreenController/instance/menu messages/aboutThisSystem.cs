aboutThisSystem 
	"Identify software version"

	| aString eToySystem aNumber |
	aString _ Smalltalk version.
	(eToySystem _ Smalltalk at: #EToySystem ifAbsent: [nil]) ifNotNil:
		[aString _ aString, '
EToy System: ', eToySystem version, ' of ', eToySystem versionDate].
	aNumber _ ChangeSorter highestNumberedChangeSet.
	aNumber > 0 ifTrue:
		[aString _ aString, '
Highest-numbered Change Set: ', aNumber printString].
	^ self inform: aString