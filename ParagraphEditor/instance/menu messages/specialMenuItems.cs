specialMenuItems
	"Refer to comment under #presentSpecialMenu.  .
	 : added objectsReferencingIt,"

	^ #(	'Transcript cr; show: ''testing'''
			'view superView model inspect'
			'view superView model browseObjClass'
			'view display'
			'self inspect'
			'view backgroundColor: Color fromUser'
			'view topView inspect'
			'self compareToClipboard'
			'view insideColor: Form white'
			'self objectsReferencingIt'
		) 