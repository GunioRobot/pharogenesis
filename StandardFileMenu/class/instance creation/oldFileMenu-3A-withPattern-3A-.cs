oldFileMenu: aDirectory withPattern: aPattern

	World ifNil: [^PluggableFileList oldFileMenu: aDirectory].
	^super new oldFileFrom: aDirectory withPattern: aPattern