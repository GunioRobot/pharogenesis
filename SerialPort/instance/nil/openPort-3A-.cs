openPort: portNumber
	"Open the given serial port, using the settings specified by my instance variables."

	self close.
	self primClosePort: portNumber.
	self primOpenPort: portNumber
		baudRate: baudRate
		stopBitsType: stopBitsType
		parityType: parityType
		dataBits: dataBits
		inFlowControlType: inputFlowControlType
		outFlowControlType: outputFlowControlType
		xOnByte: xOnByte
		xOffByte: xOffByte.
	port := portNumber.
