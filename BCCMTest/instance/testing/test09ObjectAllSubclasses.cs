test09ObjectAllSubclasses

	| n2 |
	n2 _ Object allSubclasses size.
	self assert: n2 = (Object allSubclasses
			select: [:cls | cls class class == Metaclass
					or: [cls class == Metaclass]]) size