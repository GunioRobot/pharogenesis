initialize
	"Initialize a blank ChangeList.  Set the contentsSymbol to reflect whether diffs will initally be shown or not"

	contentsSymbol _ Preferences diffsInChangeList
		ifTrue:
			[self defaultDiffsSymbol]
		ifFalse:
			[#source].
	changeList _ OrderedCollection new.
	list _ OrderedCollection new.
	listIndex _ 0.
	super initialize