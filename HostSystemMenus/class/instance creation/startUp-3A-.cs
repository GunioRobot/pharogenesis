startUp: resuming
	resuming ifFalse: [^self].
	self clearDefault.
	[self setDefaultMenuProxyClass] ifError: [:err :rcvr | ].