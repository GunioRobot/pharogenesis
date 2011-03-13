methodConflictsWithOppositeCategory
	"Check to see if ANY change set on the other side shares any methods with the selected change set; if so, open a browser on all such."

	| aList otherCategory |

	otherCategory := (parent other: self) changeSetCategory.
	aList := myChangeSet 
		messageListForChangesWhich: [ :aClass :aSelector |
			aClass notNil and: 
				[otherCategory 
					hasChangeForClassName: aClass name 
					selector: aSelector 
					otherThanIn: myChangeSet]
		]
		ifNone: [^ self inform: 
'There are no methods that appear both in
this change set and in any change set
(other than this one) on the other side.'].
	
	MessageSet 
		openMessageList: aList 
		name: 'Methods in "', myChangeSet name, '" also in some other change set in category ', otherCategory categoryName,' (', aList size printString, ')'
	