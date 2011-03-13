authoringPrototype
	| aMorph aForm |
	aMorph _ super authoringPrototype.
	aForm _ ScriptingSystem formAtKey: 'Image'.
	aForm ifNil: [aForm _ aMorph image rotateBy: 90].
	aMorph image: aForm.
	^ aMorph