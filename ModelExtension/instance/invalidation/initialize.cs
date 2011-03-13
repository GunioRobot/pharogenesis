initialize
	super initialize.
	lock := Semaphore forMutualExclusion.  
	interests := IdentityBag new.
	SystemChangeNotifier uniqueInstance 
		notify: self
		ofSystemChangesOfItem: #class
		using: #classChanged:.
	SystemChangeNotifier uniqueInstance 
		notify: self
		ofSystemChangesOfItem: #method
		using: #classChanged:.
