methodsWithCompiledCall
	"Returns all methods containing compiled in external prim calls.  
	If the by compilation subclass has disabled some, this method does *not*  
	return all methods containing prim calls (use >>methodsWithCall in this 
	case). "
	^ (SystemNavigation new
		allMethodsSelect: [:method | method primitive = 117])
		reject: [:method | method actualClass == ProtoObject]