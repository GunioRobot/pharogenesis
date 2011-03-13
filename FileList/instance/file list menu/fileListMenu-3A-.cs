fileListMenu: aMenu

	fileName
		ifNil: [^ self noFileSelectedMenu: aMenu]
		ifNotNil: [^ self fileSelectedMenu: aMenu].
