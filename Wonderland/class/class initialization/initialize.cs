initialize
	"Initialize the WonderlandClass by creating the ActorPrototypeClasses collection"
	self initializeWonderlandConstants.
	ActorPrototypeClasses _ Dictionary new.
	FileList registerFileReader: self.
	 (TheWorldMenu respondsTo: #registerOpenCommand:)
         ifTrue: [TheWorldMenu registerOpenCommand: {'Wonderland 3D'. {self. #new}}].
