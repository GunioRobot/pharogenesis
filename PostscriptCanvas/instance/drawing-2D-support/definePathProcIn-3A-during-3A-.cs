definePathProcIn: pathBlock during: duringBlock 
	"Bracket the output of pathBlock (which is passed the receiver) in 
	gsave 
		newpath 
			<pathBlock> 
		closepath 
		<duringBlock> 
	grestore 
	"
	| retval |
	self
		preserveStateDuring: [:tgt | 
			self comment: 'begin pathProc path block'.
			target newpath.
			pathBlock value: tgt.
			target closepath.
			self comment: 'begin pathProc during block'.
			retval := duringBlock value: tgt.
			self comment: 'end pathProc'].
	^ retval