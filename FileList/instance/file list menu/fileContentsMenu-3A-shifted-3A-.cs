fileContentsMenu: aMenu shifted: shifted

| shiftMenu |
^ shifted 
	ifFalse: [aMenu 
		labels: 
'get entire file
view as hex
browse changes
find...(f)
find again (g)
set search string (h)
do again (j)
undo (z)
copy (c)
cut (x)
paste (v)
paste...
do it (d)
print it (p)
inspect it (i)
fileIn selection
accept (s)
cancel (l)
more...' 
		lines: #(3 6 8 12 16 18)
		selections: #(get getHex browseChanges
find findAgain setSearchString
again undo
copySelection cut paste pasteRecent
doIt printIt inspectIt fileItIn
accept cancel
shiftedYellowButtonActivity)]

	ifTrue: [shiftMenu _ ParagraphEditor shiftedYellowButtonMenu.
		aMenu 
			labels: shiftMenu labelString 
			lines: shiftMenu lineArray
			selections: shiftMenu selections]

