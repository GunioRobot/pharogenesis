rehashAllSets
	"Set rehashAllSets"	
	self withAllSubclassesDo: [ :setClass |
		| instances |
		instances := setClass allInstances.
		instances isEmpty ifFalse: [
			1 to: instances size do: [ :index |
				(instances at: index) rehash ] ] ]