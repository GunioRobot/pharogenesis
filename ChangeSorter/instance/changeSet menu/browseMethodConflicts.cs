browseMethodConflicts
	"Check to see if any other change set also holds changes to any methods in the selected change set; if so, open a browser on all such."

	| aList aClass aSelector |
	aList _ myChangeSet changedMessageListAugmented select:
		[:aChange |
			MessageSet parse: aChange toClassAndSelector: [:cls :sel | aClass _ cls.  aSelector _ sel].
			(ChangeSorter allChangeSetsWithClass: aClass selector: aSelector) size > 1].

	aList size == 0 ifTrue: [^ self inform: 'No other change set has changes
for any method in this change set.'].
	
	MessageSet openMessageList: aList name: 'Methods in "', myChangeSet name, '" that are also in other change sets (', aList size printString, ')'
	