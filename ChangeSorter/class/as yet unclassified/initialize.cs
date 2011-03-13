initialize
	"Initialize the class.  1991-tck
	Modified 1/12/96 sw: added a bunch of new items, not all of them implemented yet.  2/2/96 sw: added browse change set.  Also made it such that if AllChangeSets already exists, this won't clobber the existing order.  2/5/96 sw: changed wording of some items
	5/8/96 sw: added subtractOtherSide
	5/29/96 sw: added SingleCngSetMenu, for single change sorter
	5/30/96 sw: added fileIntoNewChangeSet
	7/23/96 di: removed SingleCngSetMenu, since not used"

	AllChangeSets == nil ifTrue:
		[AllChangeSets _ OrderedCollection new].
	self gatherChangeSets.

	CngSetMenu _ PopUpMenu labels: 
'make changes go to me
new...
file into new...
show...
fileOut
browse
rename
copy all to other side
subtract other side
remove'    lines: #(1 3 7 9).
	CngSetSelectors  _ 
		#(newCurrent newSet fileIntoNewChangeSet chooseCngSet fileOut browseChangeSet rename copyToOther subtractOtherSide remove).

	ClassMenu _ PopUpMenu labels: 
'browse class
browse full
inst var refs
class vars
copy to other side
forget' 
			lines: #().
	ClassSelectors _ 
		#(browse browseFull instVarRefs classVariables copyToOther forget).

	MsgListMenu _ PopUpMenu labels: 
'fileOut
senders
implementors
senders of...
implementors of...
implementors of sent msgs
versions
copy to other side
forget' 
			lines: #(1 6 7).
	MsgListSelectors _ 
		#(fileOut senders implementors browseSendersOfMessages messages
		allImplementorsOf versions copyToOther forget).
	false ifTrue: [
		"Just so senders will find it here!!!  Never executed."
		(CngsMsgList new) fileOut; senders; implementors; messages;  
			versions; copyToOther; forget.
		(MessageListController new) browseSendersOfMessages; 
			allImplementorsOf].

	"
	ChangeSorter initialize.
	GeneralListController allInstancesDo:
		[:each  | each model parent class == ChangeSorter ifTrue: [
			each yellowButtonMenu: ClassMenu 
				yellowButtonMessages: ClassSelectors.
			each yellowButtonMenu: MsgListMenu 
				yellowButtonMessages: MsgListSelectors]].
	"