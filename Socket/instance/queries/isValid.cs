isValid
	"Return true if this socket contains a valid, non-nil socket handle."

	| status |
	socketHandle ifNil: [^ false].
	status _ self primSocketConnectionStatus: socketHandle.
	^ status ~= InvalidSocket
