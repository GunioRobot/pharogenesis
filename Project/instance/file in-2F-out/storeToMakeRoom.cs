storeToMakeRoom
	"Write out enough projects to fulfill the space goals.
	Include the size of the project about to come in."

	| params memoryEnd goalFree cnt gain proj skip tried |
	GoalFreePercent ifNil: [GoalFreePercent _ 33].
	GoalNotMoreThan ifNil: [GoalNotMoreThan _ 20000000].
	params _ SmalltalkImage current  getVMParameters.
	memoryEnd	_ params at: 3.
"	youngSpaceEnd	_ params at: 2.
	free _ memoryEnd - youngSpaceEnd.
"
	goalFree _ GoalFreePercent asFloat / 100.0 * memoryEnd.
	goalFree _ goalFree min: GoalNotMoreThan.
	world isInMemory ifFalse: ["enough room to bring it in"
		goalFree _ goalFree + (self projectParameters at: #segmentSize ifAbsent: [0])].
	cnt _ 30.
	gain _ Smalltalk garbageCollectMost.
	"skip a random number of projects that are in memory"
	proj _ self.  skip _ 6 atRandom.
	[proj _ proj nextInstance ifNil: [Project someInstance].
		proj world isInMemory ifTrue: [skip _ skip - 1].
		skip > 0] whileTrue.
	cnt _ 0.  tried _ 0.

	[gain > goalFree] whileFalse: [
		proj _ proj nextInstance ifNil: [Project someInstance].
		proj storeSegment ifTrue: ["Yes, did send its morphs to the disk"
			gain _ gain + (proj projectParameters at: #segmentSize 
						ifAbsent: [20000]).	"a guess"
			Beeper beep.
			(cnt _ cnt + 1) > 5 ifTrue: [^ self]].	"put out 5 at most"
		(tried _ tried + 1) > 23 ifTrue: [^ self]].	"don't get stuck in a loop"