selectAllConflicts
	"Selects all method definitions in the receiver which are also in any existing change set in the system.  This makes no statement about whether the content of the methods differ, only whether there is a change represented.
"
	|  aClass aChange |
	Cursor read showWhile: 
	[1 to: changeList size do:
		[:i | aChange _ changeList at: i.
		listSelections at: i put:
			(aChange type = #method
			and: [(aClass _ aChange methodClass) notNil
			and: [(ChangeSorter allChangeSetsWithClass: aClass selector: aChange methodSelector) size > 0]])]].
	self changed: #allSelections