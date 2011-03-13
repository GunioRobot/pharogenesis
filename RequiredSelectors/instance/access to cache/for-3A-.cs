for: aClass 
	"Somewhat weird control flow, and populates the dictionary even with non-interesting things, which it probably shouldn't"
	perClassCache at: aClass ifAbsentPut: [RequirementsCache new].
	(self haveInterestsIn: aClass) 
		ifTrue: [self ensureClean]
		ifFalse: [self calculateForClass: aClass].
	^(perClassCache at: aClass) requirements