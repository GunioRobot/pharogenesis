methodsWithInitials: initials
	"Return a list of selectors representing methods whose timestamps have the given initials and which are in the protocol of this object and within the range dictated by my limitClass."

	| classToUse |
	classToUse _ self targetObject ifNotNil: [self targetObject class] ifNil: [targetClass].  "In support of lightweight uniclasses"
	^ targetClass allSelectors select:
		[:aSelector | (currentVocabulary includesSelector: aSelector forInstance: self targetObject ofClass: classToUse limitClass: limitClass) and:
			[Utilities doesMethod: aSelector forClass: classToUse bearInitials: initials]].

