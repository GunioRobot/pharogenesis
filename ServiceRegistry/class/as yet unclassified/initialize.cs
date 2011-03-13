initialize

	self rebuild.
	SystemChangeNotifier uniqueInstance
		notify: self
		ofSystemChangesOfItem: #method 
		using: #methodChanged:
		