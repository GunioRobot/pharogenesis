primitiveResume

	| proc |
	proc _ self stackTop.  "rcvr"
	"self success: ((self fetchClassOf: proc) = (self splObj: ClassProcess))."
	successFlag ifTrue: [ self resume: proc ].