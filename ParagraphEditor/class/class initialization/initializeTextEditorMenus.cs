initializeTextEditorMenus   "ParagraphEditor initializeTextEditorMenus"
		"Initialize the yellow button pop-up menu and corresponding messages."

	TextEditorYellowButtonMenu _ SelectionMenu
		labels: 
'find...(f)
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
accept (s)
cancel (l)
show bytecodes
more...' 
		lines: #(3 5 9 12 14 15)
		selections: #(find findAgain setSearchString again undo copySelection cut paste pasteRecent doIt printIt inspectIt accept cancel showBytecodes shiftedYellowButtonActivity)
