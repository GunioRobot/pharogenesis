doesMethod: aSelector forClass: aClass bearInitials: initials
	"Answer whether a method bears the given initials at the head of its time stamp"

	| aTimeStamp implementingClass aMethod |
	implementingClass := aClass whichClassIncludesSelector: aSelector.
	implementingClass ifNil: [^ false].
	(aMethod := implementingClass compiledMethodAt: aSelector)
		ifNil: [^ false].
	^ (aTimeStamp := self timeStampForMethod: aMethod) notNil and:
		[aTimeStamp beginsWith: initials]