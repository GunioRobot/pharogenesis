cacheFieldsFrom: aStream andDo: aBlock
	"Parse aStream to initialize myself. Also, report to aBlock like fieldsFrom:do: does"
	time _ 0.
	from _ to _ cc _ subject _ ''.
	self fieldsFrom: aStream do:
		[:fName :fValue |
			fName asLowercase caseOf: {
				['date'] -> [time _ self timeFrom: fValue].
				['from'] -> [from _ fValue].
				['to'] -> [to isEmpty
					ifTrue: [to _ fValue]
					ifFalse: [to _ to , ', ' , fValue]].
				['cc'] -> [cc isEmpty
					ifTrue: [cc _ fValue]
					ifFalse: [cc _ cc , ', ' , fValue]].
				['subject'] -> [subject _ fValue]}
				otherwise: [].
			aBlock value: fName value: fValue].
