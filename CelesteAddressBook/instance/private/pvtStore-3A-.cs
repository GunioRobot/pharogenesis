pvtStore: anEmail 
	| list elemPurged |
	list _ anEmail findTokens: ','.
	list
		do: [:candidate | 
			| cabc elem | 
			"First of all, destory blanks at the beginning and condense them."
			elem _ candidate withBlanksCondensed.
			"Do a simple parsing: avoid this odd things: 
			-= a double quote and a single quote in sequence surronding 
			names -= Lack of @ is rejected"
			(elem includesSubString: '@')
				ifTrue: [
					elemPurged _ String streamContents: [:stream | elem
										do: [:c | c = $'
												ifFalse: [stream nextPut: c]]].
					cabc _ contactList
								at: elemPurged
								ifAbsent: [| nc | 
									nc _ CABContact new.
									nc email: elemPurged.
									nc frequency: 1.
									contactList at: elemPurged put: nc.
									nc].
					cabc incFrequency]]