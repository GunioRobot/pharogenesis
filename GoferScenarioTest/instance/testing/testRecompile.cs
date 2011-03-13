testRecompile
	gofer load.
	self shouldnt: [ gofer recompile ] raise: Error