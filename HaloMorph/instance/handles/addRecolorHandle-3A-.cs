addRecolorHandle: haloSpec
	"Add a recolor handle to the receiver, if appropriate"

	| recolorHandle |
	 innerTarget canSetColor ifTrue:
		[recolorHandle _ self addHandle: haloSpec on: #mouseUp send: #doRecolor:with:  to: self.
		recolorHandle on: #mouseUp send: #doRecolor:with: to: self]


