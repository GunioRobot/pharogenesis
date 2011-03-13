initialize
	"Initialize the yellow button pop-up menu for a file controller; this is the same as for a general text widnow, with the addition of the top four file-related items.  5/12/96 sw"

	FileYellowButtonMenu _ PopUpMenu labels: 
'file it in
put
get
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
		lines: #(5 8 10 13 16 18).

	FileYellowButtonMessages _ 
		#(fileItIn put get getHex browseChanges find findAgain setSearchString again undo copySelection cut paste doIt printIt inspectIt accept cancel shiftedYellowButtonActivity)

"FileController initialize"
