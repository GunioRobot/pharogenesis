filterToNotCurrentChangeSet
	"Filter the receiver's list down to only those items not in the current change set"

	self filterFrom:
		[:aClass :aSelector |
			(aClass notNil and: [aSelector notNil]) and:
				[(Smalltalk changes atSelector: aSelector class: aClass) == #none]]