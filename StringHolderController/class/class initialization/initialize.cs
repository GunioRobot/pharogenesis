initialize
	"Initialize the yellow button pop-up menu and corresponding messages.
	 1/12/96 sw: added senders of it, etc.  1/15/96 sw: explain
	 1/22/96 sw: cmd keys detailed
	 1/24/96 sw: added find; moved many items to shifted side etc.
	 1/26/96 sw: made compatible with paragraph editor's version; I'm not clear on when/how this guy gets used (seemingly eg in a workspace) vs when the paragraph editor's does (seemingly in browsers)
	 2/29/96 sw: correct cmd-key equivalent for do again, and add set-search-string"

	CodeYellowButtonMenu _ 
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
	CodeYellowButtonMessages _ 
		#(find findAgain setSearchString again undo copySelection cut paste doIt printIt inspectIt accept cancel shiftedYellowButtonActivity)

	"StringHolderController initialize"