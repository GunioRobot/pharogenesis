connectToPOP
	"connect to the POP server"
	| address response |

	Socket initializeNetwork.

	address _ NetNameResolver addressForName: serverName timeout: 15.
	address = nil ifTrue: [
		self error: 'Could not find host address'].

	"connect the socket"
	self connectTo: address port: 110.
	(self waitForConnectionUntil: POPSocket standardDeadline) ifFalse: [
		self close.
		self reportToObservers: 'failed to connect to server'.
		^false ].
	"get a hello message"
	self reportToObservers: (response _ self getResponse).
	(response beginsWith: '+') ifFalse: [ self close.  ^false ].


	"login"
	self sendCommand: 'USER ', userName.
	self reportToObservers: (response _ self getResponse).
	(response beginsWith: '+') ifFalse: [ self close. ^false ].
	self sendCommand: 'PASS ', password.
	self reportToObservers: (response _ self getResponse).
	(response beginsWith: '+') ifFalse: [ self close. ^false ].

	^true