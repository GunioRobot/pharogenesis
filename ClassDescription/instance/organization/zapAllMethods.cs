zapAllMethods
	"Remove all methods in this class which is assumed to be obsolete"

	methodDict _ MethodDictionary new.
	self isMeta ifFalse: [self class zapAllMethods]