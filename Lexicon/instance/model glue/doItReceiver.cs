doItReceiver
	"This class's classPool has been jimmied to be the classPool of the class being browsed. A doIt in the code pane will let the user see the value of the class variables.  Here, if the receiver is affiliated with a specific instance, we give give that primacy"

	^ self targetObject ifNil: [self selectedClass ifNil: [FakeClassPool new]]