execute
	self workingCopies
		do: [ :copy | self recompile: copy ]