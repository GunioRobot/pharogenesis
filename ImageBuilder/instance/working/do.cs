do
	" 
	FullImageTools new do. 
	"
	[Smalltalk at: #ASSEMBLINGFULL put: true.
	self flag: #stefCommented. "
	self deleteOldSqueakLogo.
	self deleteOldWindows."
	
	self deleteOldProjects.
	self assureDefaultChangeSet.
	"self putPreferences."
	self setDisplayDepth.
	self worldFill.
	

	""
	self install.
	""
	self deletePackageWindows.
	self deleteNumberedChangeSets.
	self deleteOtherChangeSets]
		ensure: [""
			Smalltalk
				removeKey: #ASSEMBLINGFULL
				ifAbsent: [
					]].
	" 
	Smalltalk condenseChanges.  
	SmalltalkImage current snapshot: true andQuit: false.  
	"
	World restoreMorphicDisplay