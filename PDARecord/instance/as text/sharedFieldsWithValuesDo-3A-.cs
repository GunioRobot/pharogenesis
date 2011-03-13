sharedFieldsWithValuesDo: nameValueBlock

	self sharedFieldsWithBaseDo:
		[:fields :instVarBase |
		fields withIndexDo:
			[:field :i | field = 'otherFields' ifFalse:
				[nameValueBlock value: field value: (self instVarAt: instVarBase + i)]]]