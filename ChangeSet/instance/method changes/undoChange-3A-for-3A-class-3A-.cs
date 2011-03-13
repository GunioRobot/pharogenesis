undoChange: action for: selector class: class 
	"Try to undo the change.  Remember that if a changeSet says #add, but the method is missing in the image, it won't file out!

Current cng:     Add  Remove  Add+Remove
undo: Add       none  Remove  Remove
undo: Remove  Add    none     Add
undo:Add+Rem  none  none     none
(none means the method is entirely deleted from the changeSet)"

	| dictionary prev |
	dictionary _ methodChanges at: class name ifAbsent: [^self].
	prev _ dictionary at: selector ifAbsent: [^self].
	action == #addedThenRemoved ifTrue: [
		dictionary removeKey: selector ifAbsent: [].
		dictionary isEmpty ifTrue: [methodChanges removeKey: class name].
		^ self].
	action == prev ifTrue: [dictionary removeKey: selector ifAbsent: [].
		dictionary isEmpty ifTrue: [methodChanges removeKey: class name].
		^ self].
	action == #add ifTrue: [dictionary at: selector put: #remove].
	action == #remove ifTrue: [dictionary at: selector put: #add].
	dictionary isEmpty ifTrue: [methodChanges removeKey: class name]