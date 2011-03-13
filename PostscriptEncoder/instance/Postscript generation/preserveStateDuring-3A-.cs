preserveStateDuring: aBlock
	"Note that this method supplies self, and encoder, to the block"
	| retval |
	self print: 'gsave'; cr.
	retval _ aBlock value: self.
	self print: 'grestore'; cr.
	^ retval
