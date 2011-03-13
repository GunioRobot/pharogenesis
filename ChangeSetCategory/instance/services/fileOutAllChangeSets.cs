fileOutAllChangeSets
	"File out all the nonempty change sets in the current category, suppressing the checks for slips that might otherwise ensue.  Obtain user confirmation before undertaking this possibly prodigious task."

	| aList |
	aList := self elementsInOrder select:
		[:aChangeSet  | aChangeSet isEmpty not].
	aList size == 0 ifTrue: [^ self inform: 'sorry, all the change sets in this category are empty'].
	(self confirm: 'This will result in filing out ', aList size printString, ' change set(s)
Are you certain you want to do this?') ifFalse: [^ self].

	Preferences setFlag: #checkForSlips toValue: false during: 
		[ChangeSorter fileOutChangeSetsNamed: (aList collect: [:m | m name]) asSortedArray]