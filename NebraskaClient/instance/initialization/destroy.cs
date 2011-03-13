destroy
	hand ifNotNil:[hand world ifNotNil:[hand world removeHand: hand]].
	connection ifNotNil:[connection destroy].
	encoder _ canvas _ hand _ connection _ nil.