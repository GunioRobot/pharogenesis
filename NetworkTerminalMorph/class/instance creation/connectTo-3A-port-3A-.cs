connectTo: serverHost port: serverPort

	| stringSock |

	stringSock _ self socketConnectedTo: serverHost port: serverPort.
	^self new connection: stringSock
