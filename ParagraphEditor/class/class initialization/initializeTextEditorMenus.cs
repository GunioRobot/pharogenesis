initializeTextEditorMenus
	"Initialize the yellow button pop-up menu and corresponding messages.
	6/1/96 sw moved here from StringHolderController initialize so it can be shared by vanilla ParagraphEditors."

	TextEditorYellowButtonMenu _ 
		PopUpMenu 
			labels: 
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
cancel (l)
more...' 
		lines: #(3 5  8 11 13).
	TextEditorYellowButtonMessages _ 
		#(find findAgain setSearchString again undo copySelection cut paste doIt printIt inspectIt accept cancel shiftedYellowButtonActivity)

	"ParagraphEditor initializeTextEditorMenus"