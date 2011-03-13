setOption: aName value: aValue 
	| value |
	"setup options on this socket, see Unix man pages for values for 
	sockets, IP, TCP, UDP. IE SO_KEEPALIVE
	returns an array, element one is the error number
	element two is the resulting of the negotiated value.
	See getOption for list of keys"

	(socketHandle == nil or: [self isValid not])
		ifTrue: [self error: 'Socket status must valid before setting an option'].
	value _ aValue asString.
	aValue == true ifTrue: [value _ '1'].
	aValue == false ifTrue: [value _ '0'].
	^ self primSocket: socketHandle setOption: aName value: value