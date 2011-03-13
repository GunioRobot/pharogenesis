msgPaneMenu: aMenu shifted: shifted
	^ aMenu labels: 
'find...(f)
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
cancel (l)' 
		lines: #(0 3 5 8 11)
		selections: #(find findAgain setSearchString again undo copySelection cut paste doIt printIt inspectIt accept cancel)