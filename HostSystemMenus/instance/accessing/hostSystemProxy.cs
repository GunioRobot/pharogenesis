hostSystemProxy
	hostSystemProxy ifNil: [self class setDefaultMenuProxyClass].
	^hostSystemProxy