asText

	^ String streamContents:
		[:s | self allFieldsWithValuesDo:
			[:field :value | s nextPutAll: field; nextPutAll: ': '; store: value; cr]]