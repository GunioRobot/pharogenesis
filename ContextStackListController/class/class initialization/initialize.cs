initialize
	ContextStackListYellowButtonMenu _ 
		PopUpMenu labels: 'fullStack (f)
restart (r)
proceed (p)
step (t)
send (e)
where (w)
senders (n)
implementors (m)
senders of...
implementors of...
versions
inst var refs...
inst var defs...
class var refs...
class variables
class refs
browse full
more...'
	lines: #(6 11 13 16 17).
	ContextStackListYellowButtonMessages _ #(fullStack restart proceed step send where  senders implementors sendersOf messages versions browseInstVarRefs browseInstVarDefs classVarRefs browseClassVariables browseClassRefs browseFull shiftedYellowButtonActivity).

	ContextStackKeyboardCommands _ Dictionary new
		at: $e put: #send;
		at: $t put: #step;
		at: $p put: #proceed;
		at: $r put: #restart;
		at: $f put: #fullStack;
		at: $w put: #where;
		at: $n put: #senders;
		at: $m put:	#implementors;
		at: 30 asCharacter put: #up;
		at: 31 asCharacter put: #down;
		yourself.

	"ContextStackListController initialize"