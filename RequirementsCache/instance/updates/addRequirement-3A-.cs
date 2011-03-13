addRequirement: selector
	requirements ifNil: [requirements := self newRequirementsObject].
	requirements add: selector.