methodConflictsWithOtherSide
	"Check to see if the change set on the other side shares any methods with the selected change set; if so, open a browser on all such."

	| aList aClass aSelector other |
	self checkThatSidesDiffer: [^ self].
	other _ (parent other: self) changeSet.
	aList _ myChangeSet changedMessageListAugmented select:
		[:aChange |
			MessageSet parse: aChange toClassAndSelector: [:cls :sel | aClass _ cls.  aSelector _ sel].
			aClass notNil and: [(other methodChangesAtClass: aClass name) includesKey: aSelector]].

	aList size == 0 ifTrue: [^ self inform: 'There are no methods that appear
both in this change set and
in the one on the other side.'].
	
	MessageSet openMessageList: aList name: 'Methods in "', myChangeSet name, '" that are also in ', other name,' (', aList size printString, ')'
	