zapAllMethods
	"Remove all methods in this trait which is assumed to be obsolete"

	methodDict _ MethodDictionary new.
	self hasClassTrait ifTrue: [self classTrait zapAllMethods]