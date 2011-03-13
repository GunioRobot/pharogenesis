changeSetMenu: aMenu
	"Could be for a single or double changeSorter"
	parent ifNotNil: [
	^ aMenu labels: 
'make changes go to me
new...
file into new...
show...
update
fileOut
browse
rename
copy all to other side
submerge into other side
subtract other side
edit preamble...
edit postscript...
clear
remove'
		lines: #(1 3 8 11 13 )
		selections: #(newCurrent newSet fileIntoNewChangeSet chooseCngSet update fileOut browseChangeSet rename copyAllToOther submergeIntoOtherSide subtractOtherSide editPreamble editPostscript clearChangeSet remove )]

	ifNil: ["Single ChangeSorter"
	^ aMenu labels: 
'make changes go to me
new...
file into new...
show...
update
fileOut
browse
rename
edit preamble...
edit postscript...
clear
remove'
		lines: #(1 3 8 10)
		selections: #(newCurrent newSet fileIntoNewChangeSet chooseCngSet update fileOut browseChangeSet rename editPreamble editPostscript clearChangeSet remove )]