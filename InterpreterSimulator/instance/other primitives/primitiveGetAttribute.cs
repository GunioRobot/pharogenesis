primitiveGetAttribute
	"return nil as if attribute isn't defined"
		self pop: 2.  "rcvr, attr"
		self push: (self splObj: NilObject).