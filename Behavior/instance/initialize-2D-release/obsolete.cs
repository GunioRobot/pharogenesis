obsolete
	"Invalidate and recycle local messages. Remove the receiver from its 
	superclass' subclass list."

	methodDict _ MethodDictionary new.
	superclass == nil ifFalse: [superclass removeSubclass: self]