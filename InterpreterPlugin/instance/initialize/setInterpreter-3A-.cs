setInterpreter: anInterpreter 
	"Note: This is coded so that is can be run from Squeak."

	| ok |
	self export: true.
	self var: #anInterpreter type: #'struct VirtualMachine*'.
	interpreterProxy _ anInterpreter.
	ok _ self cCode: 'interpreterProxy->majorVersion() == VM_PROXY_MAJOR'.
	ok == false ifTrue: [^ false].
	ok _ self cCode: 'interpreterProxy->minorVersion() >= VM_PROXY_MINOR'.
	^ ok