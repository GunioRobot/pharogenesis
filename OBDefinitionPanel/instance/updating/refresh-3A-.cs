refresh: announcement
	| oldDefinition |
	definition ifNil: [^ self].
	oldDefinition _ definition.
	definition _ self getDefinition.
	definition text = oldDefinition text ifTrue: [^ self].
	self canDiscardEdits
			ifTrue: [self changed: #text]
			ifFalse: [self changed: #codeChangedElsewhere]