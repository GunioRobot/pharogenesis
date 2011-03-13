setTransform: command
	| transformEnc |
	transformEnc _ command at: 2.
	transform _ self class decodeTransform: transformEnc