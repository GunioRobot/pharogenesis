initializeST80ColorTable
	"Initiialize the colors that characterize the ST80 dialect"

	ST80ColorTable _ IdentityDictionary new.
	#(	(temporaryVariable blue italic)
		(methodArgument blue normal)
		(methodSelector black bold)
		(blockArgument red normal)
		(comment brown normal)
		(variable magenta normal)
		(literal	tan normal)
		(keyword darkGray bold)
		(prefixKeyword veryDarkGray bold)
		(setOrReturn black bold)) do:
			[:aTriplet |
				ST80ColorTable at: aTriplet first put: aTriplet allButFirst]

"DialectStream initialize"