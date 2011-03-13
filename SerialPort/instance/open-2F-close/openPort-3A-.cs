openPort: portNumber
	"Open the given serial port, using the settings specified by my instance variables. If the port cannot be opened, such as when it is alreay in use, answer nil."  "(DNS)"

	self close.
	(self primClosePort: portNumber) isNil ifTrue: [
		^ nil ].
	(self primOpenPort: portNumber
		baudRate: baudRate
		stopBitsType: stopBitsType
		parityType: parityType
		dataBits: dataBits
		inFlowControlType: inputFlowControlType
		outFlowControlType: outputFlowControlType
		xOnByte: xOnByte
		xOffByte: xOffByte) isNil ifTrue: [
			^ nil ].
	port _ portNumber
