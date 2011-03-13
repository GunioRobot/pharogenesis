tileScriptCommands
	"Return a list of typed-command arrays of the form:
		#command <selector> <balloon help>"
	self flag: #deferred.  "'need way for user to save own help"
	^(Array with: {#command. #'emptyScript'. 'a new empty script'}),
		(self class namedTileScriptSelectors asSortedArray collect:
			[:sel | Array with: #command with: sel with: 'a user-written script'])