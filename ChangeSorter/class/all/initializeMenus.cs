initializeMenus
	"ChangeSorter initializeMenus"

	CngSetMenu _ PopUpMenu labels: 
'make changes go to me
new...
file into new...
show...
fileOut
browse
rename
copy all to other side
submerge into other side
subtract other side
edit preamble...
edit postscript...
clear
remove'    lines: #(1 3 7 10 12).
	CngSetSelectors  _ 
		#(newCurrent newSet fileIntoNewChangeSet chooseCngSet fileOut browseChangeSet rename copyToOther submergeIntoOtherSide subtractOtherSide editPreamble editPostscript clearChangeSet remove).

	ClassMenu _ PopUpMenu labels: 
'copy to other side
delete from this change set
browse full
inst var refs...
inst var defs...
class var refs...
class vars' 
			lines: #(2 3).
	ClassSelectors _ 
		#(copyToOther forget browseFull  instVarRefs instVarDefs classVarRefs classVariables ).
	self initializeMessageListMenu.


"	ChangeSorter initializeMenus.
	GeneralListController allInstancesDo:
		[:each  | each model parent class == ChangeSorter ifTrue:
			[each yellowButtonMenu: ClassMenu 
				yellowButtonMessages: ClassSelectors.
			each yellowButtonMenu: MsgListMenu 
				yellowButtonMessages: MsgListSelectors]].
	"