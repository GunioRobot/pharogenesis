primitiveVMPath
	"Return a string containing the path name of VM's directory."

	| s sz |
	sz _ self vmPathSize.
	s _ self instantiateClass: (self splObj: ClassString) indexableSize: sz.
	self vmPathGet: (s + BaseHeaderSize) Length: sz.
	self pop: 1.  "rcvr"
	self push: s.
