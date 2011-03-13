fileContentsMenu: aMenu shifted: shifted

| shiftMenu |
^ shifted 
	ifFalse: [aMenu 
		labels: 
'file it in
get entire file
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
do it (d)
print it (p)
inspect it (i)
accept (s)
cancel (l)
more...' 
		lines: #(4 7 9 12 15 17)
		selections: #(fileItIn get getHex browseChanges find findAgain setSearchString again undo copySelection cut paste doIt printIt inspectIt accept cancel shiftedYellowButtonActivity)]

	ifTrue: [shiftMenu _ PluggableTextController shiftedYellowButtonMenu.
		aMenu 
			labels: shiftMenu labelString 
			lines: shiftMenu lineArray
			selections: PluggableTextController shiftedYellowButtonMessages]

