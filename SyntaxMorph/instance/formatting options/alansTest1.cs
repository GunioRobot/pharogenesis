alansTest1
	
	| root |

	root _ self rootTile ifNil: [self].
	^root valueOfProperty: #alansNewStyle ifAbsent: [self usingClassicTiles not]