setSuccessor: newSuccessor

	successor _ newSuccessor.
	paragraph ifNotNil: [paragraph wantsColumnBreaks: successor notNil].
