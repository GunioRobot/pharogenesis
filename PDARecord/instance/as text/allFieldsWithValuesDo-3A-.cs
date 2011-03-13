allFieldsWithValuesDo: nameValueBlock

	self sharedFieldsWithValuesDo: nameValueBlock.
	otherFields ifNotNil:
		[otherFields associationsDo:
			[:assn | nameValueBlock value: assn key value: assn value]]