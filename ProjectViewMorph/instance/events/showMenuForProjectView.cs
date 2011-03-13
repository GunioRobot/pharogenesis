showMenuForProjectView
	| menu selection |
	(menu _ CustomMenu new)
		add: 'enter this project'
		action: [^ self enter];
		
		add: 'ENTER ACTIVE'
		action: [self setProperty: #wasOpenedAsSubproject toValue: true.
			^ self enterAsActiveSubproject];
		
		add: 'PUBLISH (also saves a local copy)'
		action: [^ project storeOnServerShowProgressOn: self forgetURL: false];
		
		add: 'PUBLISH to a different server'
		action: [project forgetExistingURL.
			^ project storeOnServerShowProgressOn: self forgetURL: true];
		
		add: 'see if server version is more recent'
		action: [^ self checkForNewerVersionAndLoad].
	selection _ menu build startUpCenteredWithCaption: 'Project Named
' , '"' , project name , '"'.
	selection
		ifNil: [^ self].
	selection value