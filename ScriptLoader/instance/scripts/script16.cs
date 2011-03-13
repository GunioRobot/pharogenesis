script16
	"Traits introduction:
	The packages need to be loaded in the following order, one by one.
	"
	
	self loadOneAfterTheOther: 	
			#('Traits.bootstrap-al.1.mcz'
				'Kernel.bootstrap-al.1.mcz'
				'Kernel.bootstrap-al.2.mcz'
				'Monticello-al.287.mcz'
				'Traits-al.198.mcz'
				'Kernel-al.70.mcz'
				'System-al.52.mcz'
				'Tools-al.43.mcz') merge: false.
	
	
