noteChangeType: newChangeType

	(changeType == #addedThenRemoved and: [newChangeType == #change])
		ifTrue: [changeType _ #add]
		ifFalse: [changeType _ newChangeType]