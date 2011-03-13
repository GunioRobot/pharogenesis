specialMenuItems
	"Refer to comment under #presentSpecialMenu.  4/29/96 sw."

	^ #(	'Transcript cr; show: ''testing'''
			'view superView model inspect'
			'view superView model browseObjClass'
			'view display'
			'self inspect'
			'view backgroundColor: Color fromUser'
			'view topView inspect'
			'self compareToClipboard'
			'view insideColor: Form white'
		) 