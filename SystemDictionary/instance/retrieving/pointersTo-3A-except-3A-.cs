pointersTo: anObject except: objectsToExclude
	"Find all occurrences in the system of pointers to the argument anObject. Remove objects in the exclusion list from the results."

	| results anObj |
	Smalltalk garbageCollect.
	"big collection shouldn't grow, so it's contents array is always the same"
	results _ OrderedCollection new: 1000.

	"allObjectsDo: is expanded inline to keep spurious
	 method and block contexts out of the results"
	anObj _ self someObject.
	[0 == anObj] whileFalse: [
		anObj isInMemory ifTrue: [
			(anObj pointsTo: anObject) ifTrue: [
				"exclude the results collector and contexts in call chain"
				((anObj ~~ results collector) and:
				 [(anObj ~~ objectsToExclude) and:
				 [(anObj ~~ thisContext) and:
				 [(anObj ~~ thisContext sender) and:
				 [anObj ~~ thisContext sender sender]]]])
					 ifTrue: [ results add: anObj ].
			]].
		anObj _ anObj nextObject.
	].
	objectsToExclude do: [ :obj | results removeAllSuchThat: [ :el | el == obj]].

	^ results asArray
