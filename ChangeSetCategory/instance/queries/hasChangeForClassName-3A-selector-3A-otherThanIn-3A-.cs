hasChangeForClassName: aClassName selector: aSelector otherThanIn: excludedChangeSet
	"Answer whether any change set in this category, other than the excluded one, has a change marked for the given class and selector"

	self elementsInOrder do:
		[:aChangeSet |
			(aChangeSet ~~ excludedChangeSet and:
				[((aChangeSet methodChangesAtClass: aClassName) includesKey: aSelector)]) ifTrue:	[^ true]].

	^ false