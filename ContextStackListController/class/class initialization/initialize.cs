initialize
	"Modified 1/12/96 sw"

	ContextStackListYellowButtonMenu _ 
		PopUpMenu labels: 'fullStack
restart
proceed
step
send
where
senders
implementors
senders of...
implementors of...
browse full'
	lines: #(6 11).
	ContextStackListYellowButtonMessages _ #(fullStack restart proceed step send where senders implementors sendersOf messages browseFull)

	"ContextStackListController initialize"