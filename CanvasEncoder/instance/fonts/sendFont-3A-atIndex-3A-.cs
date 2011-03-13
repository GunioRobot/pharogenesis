sendFont: aFont atIndex: index
	"transmit the given fint to the other side"
	self sendCommand: {
		String with: CanvasEncoder codeFont.
		self class encodeInteger: index.
		self class encodeFont: aFont }.
