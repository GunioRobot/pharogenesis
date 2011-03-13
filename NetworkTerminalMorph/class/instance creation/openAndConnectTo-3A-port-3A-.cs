openAndConnectTo: serverHost port: serverPort

	| stringSock me |

	stringSock _ self socketConnectedTo: serverHost port: serverPort.
	me _ self new connection: stringSock.
	^me openInStyle: #naked
