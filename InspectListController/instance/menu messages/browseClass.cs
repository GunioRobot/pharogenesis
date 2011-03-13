browseClass
	"Create and schedule a class browser on the class of the current inspected.  1/25/96 sw"

	self controlTerminate.
	Browser newOnClass: self classOfSelection theNonMetaClass.
	self controlInitialize