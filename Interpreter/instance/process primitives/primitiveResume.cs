primitiveResume
"put this process on the scheduler's lists thus allowing it to proceed next time there is a chance for processes of it's priority level"
	| proc |
	proc _ self stackTop.  "rcvr"
	"self success: ((self fetchClassOf: proc) = (self splObj: ClassProcess))."
	successFlag ifTrue: [ self resume: proc ].