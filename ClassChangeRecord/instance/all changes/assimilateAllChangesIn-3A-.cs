assimilateAllChangesIn: otherRecord

	| selector changeRecord changeType |
	otherRecord isClassRemoval ifTrue: [^ self noteChangeType: #remove].

	otherRecord allChangeTypes do:
		[:chg | self noteChangeType: chg fromClass: self realClass].

	otherRecord methodChanges associationsDo:
		[:assn | selector _ assn key. changeRecord _ assn value.
		changeType _ changeRecord changeType.
		(changeType == #remove or: [changeType == #addedThenRemoved])
			ifTrue:
				[changeType == #addedThenRemoved
					ifTrue: [self atSelector: selector put: #add].
				self noteRemoveSelector: selector priorMethod: nil
						lastMethodInfo: changeRecord methodInfoFromRemoval]
			ifFalse: 
				[self atSelector: selector put: changeType]].
