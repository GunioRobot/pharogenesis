preserveStateDuring:aBlock
	| retval |
     self gsave.
	retval _ aBlock value:self.
     self grestore.	
	^retval
