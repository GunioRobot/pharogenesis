shiftedYellowButtonMenu
	"Answer the menu to be presented when the yellow button is pressed while the shift key is down. 3/13/96 sw
	 5/27/96 sw: added font menu"

	^ PopUpMenu labels: 
'set font... (k)
set style... (K)
explain
format
file it in
recognizer (r)
spawn (o)
browse it (b)
senders of it (n)
implementors of it (m)
references to it (N)
selectors containing it (W)
method strings with it
method source with it
special menu...
more...' 
		lines: #(2 7 14).