connect

	mytargetip _ FillInTheBlank 
		request: 'Connect to?' 
		initialAnswer: (mytargetip ifNil: ['']).
	mytargetip _ NetNameResolver stringFromAddress: (
		(NetNameResolver addressFromString: mytargetip) ifNil: [^mytargetip _ '']
	)
