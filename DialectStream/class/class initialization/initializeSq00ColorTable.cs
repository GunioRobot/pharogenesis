initializeSq00ColorTable
	"Initiialize the colors that characterize the Sq00 dialect"

	Sq00ColorTable _ IdentityDictionary new.
	#(	(temporaryVariable black normal)
		(methodArgument black normal)
		(methodSelector black bold)
		(blockArgument black normal)
		(comment brown normal)
		(variable black normal)
		(literal	 blue normal)
		(keyword darkGray bold)
		(prefixKeyword veryDarkGray bold)
		(setOrReturn black bold)) do:
			[:aTriplet |
				Sq00ColorTable at: aTriplet first put: aTriplet allButFirst]