accept: aText notifying: aController
	^ self 
		withDefinitionDo: [:def | [def accept: aText notifying: aController]
									on: OBAnnouncerRequest
									do: [:notification | notification resume: self announcer]]
		ifNil: [true]