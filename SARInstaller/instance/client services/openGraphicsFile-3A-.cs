openGraphicsFile: memberOrName
	| member morph |
	member _ self memberNamed: memberOrName.
	member ifNil: [ ^self errorNoSuchMember: memberOrName ].
	morph _ (World drawingClass fromStream: member contentStream binary).
	morph ifNotNil: [ morph openInWorld ].
	self installed: member.