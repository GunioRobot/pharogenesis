seeIfNameChanged

	| nameBefore nameNow |

	nameBefore _ self valueOfProperty: #SafeProjectName ifAbsent: ['???'].
	nameNow _ self safeProjectName.
	(submorphs notEmpty and: [nameBefore = nameNow]) ifTrue: [^self].
	self addProjectNameMorphFiller.
