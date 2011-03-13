cngSetActivity
	"Put up a menu and do what the user says.  1991 tck;
	5/9/96 sw: highlight button while mouse down
	5/29/96 sw: use different menu for single-change-sorter case"

	| index reply |

	buttonView displayComplemented.
	parent == nil "Single change sorter"
		ifTrue:
			[reply _ SingleCngSetMenu startUp.
			reply == nil ifFalse:
				[self perform: reply]]
		ifFalse:
			[index _ CngSetMenu startUp.
			index == 0 ifFalse:
				[self perform: (CngSetSelectors at: index)]].
	buttonView displayNormal