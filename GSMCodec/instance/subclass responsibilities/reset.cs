reset
	"Reset my encoding/decoding state to prepare to encode or decode a new sound stream."

	encodeState _ self primNewState.
	decodeState _ self primNewState.
