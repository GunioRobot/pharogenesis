tileScriptCommands
	"Return a list of typed-command arrays of the form:
		#script <result type> <command> <argType>"

	^  self class namedTileScriptSelectors asSortedArray collect:
			[:sel | Array with: #script with: #command with: sel]
