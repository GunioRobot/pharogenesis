loadEToyFromServer
	"Go to two common servers and look for etoys.  Let the user choose one.  Do not bring it to the user's disk.  A file on the server called etoys.list has the names of the files. "

	| doc urls names aName this aHolder |
	"EToySystem loadEToyFromServer"
	Cursor wait showWhile:
		[urls _ self newEToysOn: 
			(self serverUrls collect: [:url | url, 'etoys/']).
		names _ urls collect: [:each | (each findTokens: '/') last]].
		names _ names collect: [:n | n sansPeriodSuffix].  "strip the .sqo"

		names size = 0 ifTrue: [^ self inform: 'There don''t seem to be any EToys for this version'].

	Cursor wait showWhile: 
		[aName _ (SelectionMenu selections: names) startUpWithCaption: 'Choose an EToy'.
		aName size == 0 ifFalse: 
			[this _ urls at: (names indexOf: aName).
			doc _ HTTPSocket httpGet: this accept: 'application/octet-stream'.
			doc class == String
				ifTrue: [self inform: 'Oops. Can''t find EToy ',aName]
				ifFalse:
					[doc reset.
					aHolder _ doc fileInObjectAndCode.
					"code filed in is the Model class"
					aHolder ifNotNil: [EToyPlayer openFromSaveFileOn: aHolder]]]]