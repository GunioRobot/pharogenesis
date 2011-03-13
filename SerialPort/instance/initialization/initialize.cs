initialize
	"Default port settings."

	port _ nil.					"set when opened"
	baudRate _ 9600.			"9600 baud"
	stopBitsType _ 1.				"one stop bit"
	parityType _ 0.				"no parity"
	dataBits _ 8.					"8 bits"
	outputFlowControlType _ 0.	"none"
	inputFlowControlType _ 0.	"none"
	xOnByte _ 19.				"ctrl-S"
	xOffByte _ 24.				"ctrl-X"
